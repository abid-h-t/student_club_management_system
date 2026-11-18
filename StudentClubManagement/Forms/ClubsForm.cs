using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StudentClubManagement.DataAccess;
using StudentClubManagement.Models;
using StudentClubManagement.Utilities;

namespace StudentClubManagement.Forms
{
    /// <summary>
    /// Add, edit, delete and search clubs. Every button calls a stored
    /// procedure through ClubRepository and then reloads the grid.
    /// </summary>
    public partial class ClubsForm : Form
    {
        private readonly ClubRepository _clubs = new ClubRepository();

        /// <summary>ID of the club loaded into the fields (0 = none, i.e. "new club" mode).</summary>
        private int _selectedClubId;

        /// <summary>Whether the loaded club was active, to detect a deactivation on Update.</summary>
        private bool _selectedWasActive;

        public ClubsForm()
        {
            InitializeComponent();
            UiHelper.ConfigureGrid(dgvClubs);
        }

        private void ClubsForm_Load(object sender, EventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        // ------------------------------------------------------------------
        // Grid loading
        // ------------------------------------------------------------------

        /// <summary>
        /// Reloads the grid: sp_Club_Search when the search box has text,
        /// otherwise sp_Club_GetAll. Called after every change.
        /// </summary>
        private void RefreshGrid()
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                DataTable table = keyword.Length > 0 ? _clubs.Search(keyword) : _clubs.GetAll();

                dgvClubs.DataSource = table;
                UiHelper.HideColumns(dgvClubs, "CreatedAt");
                UiHelper.SetColumnWeight(dgvClubs, 55, "ClubID", "IsActive");
                UiHelper.SetColumnWeight(dgvClubs, 220, "Description");
                lblCount.Text = table.Rows.Count + (table.Rows.Count == 1 ? " club" : " clubs") +
                                (keyword.Length > 0 ? " matching \"" + keyword + "\"" : "");
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex);
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
        }

        /// <summary>
        /// Clicking a grid row loads that club (fresh from sp_Club_GetByID)
        /// into the detail fields.
        /// </summary>
        private void dgvClubs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return; // header row
            }

            try
            {
                int clubId = Convert.ToInt32(dgvClubs.Rows[e.RowIndex].Cells["ClubID"].Value);
                Club club = _clubs.GetById(clubId);

                if (club == null)
                {
                    UiHelper.ShowWarning("This club no longer exists. The list will be refreshed.");
                    ClearFields();
                    RefreshGrid();
                    return;
                }

                _selectedClubId = club.ClubID;
                _selectedWasActive = club.IsActive;

                txtClubId.Text = club.ClubID.ToString();
                txtClubName.Text = club.ClubName;
                cboCategory.Text = club.Category;
                txtAdvisor.Text = club.AdvisorName ?? string.Empty;
                dtpFounded.Value = club.FoundedDate;
                chkIsActive.Checked = club.IsActive;
                txtDescription.Text = club.Description ?? string.Empty;
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex);
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
        }

        // ------------------------------------------------------------------
        // Validation
        // ------------------------------------------------------------------

        /// <summary>
        /// Checks the fields before any database call: club name and category
        /// are required, and the founded date cannot be in the future.
        /// Returns a filled Club object, or null when something is invalid.
        /// </summary>
        private Club ReadAndValidateFields()
        {
            if (Validator.IsBlank(txtClubName.Text))
            {
                UiHelper.ShowValidation("Club name is required.", txtClubName);
                return null;
            }

            if (Validator.IsBlank(cboCategory.Text))
            {
                UiHelper.ShowValidation("Category is required. Choose one from the list or type your own.", cboCategory);
                return null;
            }

            if (dtpFounded.Value.Date > DateTime.Today)
            {
                UiHelper.ShowValidation("Founded date cannot be in the future.", dtpFounded);
                return null;
            }

            return new Club
            {
                ClubID = _selectedClubId,
                ClubName = txtClubName.Text.Trim(),
                Category = cboCategory.Text.Trim(),
                AdvisorName = txtAdvisor.Text.Trim(),
                FoundedDate = dtpFounded.Value.Date,
                IsActive = chkIsActive.Checked,
                Description = txtDescription.Text.Trim()
            };
        }

        // ------------------------------------------------------------------
        // Buttons
        // ------------------------------------------------------------------

        /// <summary>Add: validate, call sp_Club_Insert, show the new ID, refresh the grid.</summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Club club = ReadAndValidateFields();
            if (club == null)
            {
                return;
            }

            try
            {
                int newId = _clubs.Insert(club);
                UiHelper.ShowInfo("Club \"" + club.ClubName + "\" was added with ID " + newId + ".");
                ClearFields();
                RefreshGrid();
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex); // e.g. 50003: club name already exists
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
        }

        /// <summary>Update: needs a selected club, validates, then calls sp_Club_Update.</summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedClubId == 0)
            {
                UiHelper.ShowWarning("Click a club in the list first, then change its details and press Update.");
                return;
            }

            Club club = ReadAndValidateFields();
            if (club == null)
            {
                return;
            }

            // Deactivating a club also sets its memberships to Inactive (done
            // inside sp_Club_Update), so ask before doing it.
            if (_selectedWasActive && !club.IsActive &&
                !UiHelper.Confirm("You are marking \"" + club.ClubName + "\" as inactive.\n\n" +
                                  "All of its active memberships will also be set to Inactive. Continue?"))
            {
                return;
            }

            try
            {
                _clubs.Update(club);
                UiHelper.ShowInfo("Club \"" + club.ClubName + "\" was updated.");
                ClearFields();
                RefreshGrid();
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex);
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
        }

        /// <summary>
        /// Delete: needs a selected club and a confirmation, then calls
        /// sp_Club_Delete (which refuses if the club has members or events).
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedClubId == 0)
            {
                UiHelper.ShowWarning("Click a club in the list first, then press Delete.");
                return;
            }

            if (!UiHelper.Confirm("Delete the club \"" + txtClubName.Text + "\"?\n\nThis cannot be undone."))
            {
                return;
            }

            try
            {
                _clubs.Delete(_selectedClubId);
                UiHelper.ShowInfo("The club was deleted.");
                ClearFields();
                RefreshGrid();
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex); // e.g. 50004: club still has memberships or events
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        /// <summary>Empties the detail fields and returns to "new club" mode.</summary>
        private void ClearFields()
        {
            _selectedClubId = 0;
            _selectedWasActive = false;

            txtClubId.Text = "(new)";
            txtClubName.Clear();
            cboCategory.SelectedIndex = -1;
            cboCategory.Text = string.Empty;
            txtAdvisor.Clear();
            dtpFounded.Value = DateTime.Today;
            chkIsActive.Checked = true;
            txtDescription.Clear();

            dgvClubs.ClearSelection();
            txtClubName.Focus();
        }

        /// <summary>Search: runs sp_Club_Search with the text in the search box.</summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Validator.IsBlank(txtSearch.Text))
            {
                UiHelper.ShowValidation("Type part of a club name, category, advisor or description to search for.", txtSearch);
                return;
            }

            RefreshGrid();
        }

        /// <summary>Show All: clears the search box and lists every club again.</summary>
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            RefreshGrid();
        }

        /// <summary>Pressing Enter in the search box runs the search.</summary>
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch_Click(sender, EventArgs.Empty);
            }
        }
    }
}
