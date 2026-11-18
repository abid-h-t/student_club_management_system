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
    /// Shows the members of a club and lets the user add a student with a
    /// role, change a member's role/status, or remove a member.
    /// </summary>
    public partial class MembershipsForm : Form
    {
        /// <summary>What the grid is currently showing, so it can be refreshed the same way.</summary>
        private enum ViewMode
        {
            ClubMembers,     // sp_Membership_GetMembersByClub
            SearchResults,   // sp_Membership_Search
            AllMemberships   // sp_Membership_GetAll
        }

        private readonly ClubRepository _clubs = new ClubRepository();
        private readonly StudentRepository _students = new StudentRepository();
        private readonly MembershipRepository _memberships = new MembershipRepository();

        private ViewMode _mode = ViewMode.ClubMembers;
        private int _selectedMembershipId;   // 0 = no row selected
        private bool _loading;               // true while combo boxes are being filled

        public MembershipsForm()
        {
            InitializeComponent();
            UiHelper.ConfigureGrid(dgvMembers);

            // The role/status lists come from the same constants the database constraints use
            cboRole.Items.AddRange(Membership.Roles);
            cboEditRole.Items.AddRange(Membership.Roles);
            cboEditStatus.Items.AddRange(Membership.Statuses);
        }

        private void MembershipsForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            ClearSelection();
            RefreshGrid();
        }

        // ------------------------------------------------------------------
        // Loading
        // ------------------------------------------------------------------

        /// <summary>
        /// Fills the club list (sp_Club_GetAll) and the student list
        /// (sp_Student_GetAll). An extra "Display" column builds the text
        /// shown in each combo box.
        /// </summary>
        private void LoadComboBoxes()
        {
            _loading = true;
            try
            {
                DataTable clubs = _clubs.GetAll();
                clubs.Columns.Add("Display", typeof(string), "ClubName + IIF(IsActive, '', '  (inactive)')");
                cboClub.DisplayMember = "Display";
                cboClub.ValueMember = "ClubID";
                cboClub.DataSource = clubs;

                DataTable students = _students.GetAll();
                students.Columns.Add("Display", typeof(string), "LastName + ', ' + FirstName + '  (' + Email + ')'");
                cboStudent.DisplayMember = "Display";
                cboStudent.ValueMember = "StudentID";
                cboStudent.DataSource = students;
                cboStudent.SelectedIndex = -1;
                cboStudent.SelectedIndex = -1; // set twice: a data-bound combo ignores the first reset

                cboRole.SelectedItem = "Member";
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex);
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
            finally
            {
                _loading = false;
            }
        }

        /// <summary>Returns the ID behind the selected combo item, or 0 when nothing is selected.</summary>
        private static int GetSelectedId(ComboBox combo)
        {
            return combo.SelectedIndex >= 0 && combo.SelectedValue is int ? (int)combo.SelectedValue : 0;
        }

        /// <summary>
        /// Reloads the grid in the current view mode. Called after every
        /// add / update / remove so the list always shows what is in SQL Server.
        /// </summary>
        private void RefreshGrid()
        {
            try
            {
                DataTable table;
                string title;

                switch (_mode)
                {
                    case ViewMode.SearchResults:
                        table = _memberships.Search(txtSearch.Text.Trim());
                        title = "Memberships matching \"" + txtSearch.Text.Trim() + "\"";
                        break;

                    case ViewMode.AllMemberships:
                        table = _memberships.GetAll();
                        title = "All memberships in every club";
                        break;

                    default:
                        int clubId = GetSelectedId(cboClub);
                        table = _memberships.GetMembersByClub(clubId);
                        title = clubId == 0 ? "No club selected" : "Members of " + cboClub.Text;
                        break;
                }

                dgvMembers.DataSource = table;
                UiHelper.HideColumns(dgvMembers, "MembershipID", "StudentID", "ClubID");
                UiHelper.SetColumnWeight(dgvMembers, 150, "Email");
                lblGridTitle.Text = title + "  (" + table.Rows.Count + ")";

                // Keep the edited row selected if it is still in the list
                if (_selectedMembershipId != 0 &&
                    !UiHelper.SelectRowById(dgvMembers, "MembershipID", _selectedMembershipId))
                {
                    ClearSelection();
                }
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

        /// <summary>Forgets the selected membership and resets the edit box.</summary>
        private void ClearSelection()
        {
            _selectedMembershipId = 0;
            lblSelected.Text = "No membership selected";
            cboEditRole.SelectedIndex = -1;
            cboEditStatus.SelectedIndex = -1;
            dgvMembers.ClearSelection();
        }

        // ------------------------------------------------------------------
        // Choosing what the grid shows
        // ------------------------------------------------------------------

        /// <summary>Choosing a club lists its members (sp_Membership_GetMembersByClub).</summary>
        private void cboClub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loading)
            {
                return;
            }

            ShowClubMembers();
        }

        private void btnShowClub_Click(object sender, EventArgs e)
        {
            ShowClubMembers();
        }

        private void ShowClubMembers()
        {
            _mode = ViewMode.ClubMembers;
            txtSearch.Clear();
            ClearSelection();
            RefreshGrid();
        }

        /// <summary>Search: runs sp_Membership_Search across every club.</summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Validator.IsBlank(txtSearch.Text))
            {
                UiHelper.ShowValidation("Type part of a student name, email, club name, role or status to search for.", txtSearch);
                return;
            }

            _mode = ViewMode.SearchResults;
            ClearSelection();
            RefreshGrid();
        }

        /// <summary>All Memberships: lists every membership (sp_Membership_GetAll).</summary>
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            _mode = ViewMode.AllMemberships;
            txtSearch.Clear();
            ClearSelection();
            RefreshGrid();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch_Click(sender, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Clicking a grid row loads that membership (sp_Membership_GetByID)
        /// into the "Selected membership" box.
        /// </summary>
        private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return; // header row
            }

            try
            {
                int membershipId = Convert.ToInt32(dgvMembers.Rows[e.RowIndex].Cells["MembershipID"].Value);
                Membership membership = _memberships.GetById(membershipId);

                if (membership == null)
                {
                    UiHelper.ShowWarning("This membership no longer exists. The list will be refreshed.");
                    ClearSelection();
                    RefreshGrid();
                    return;
                }

                _selectedMembershipId = membership.MembershipID;
                lblSelected.Text = membership.StudentName + "  -  " + membership.ClubName;
                cboEditRole.SelectedItem = membership.Role;
                cboEditStatus.SelectedItem = membership.Status;
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
        // Buttons
        // ------------------------------------------------------------------

        /// <summary>
        /// Add to Club: checks that a club, a student and a role are chosen,
        /// then calls sp_Membership_AddStudentToClub. The procedure rejects
        /// duplicates, inactive clubs and a second holder of an officer role.
        /// </summary>
        private void btnAddMember_Click(object sender, EventArgs e)
        {
            int clubId = GetSelectedId(cboClub);
            if (clubId == 0)
            {
                UiHelper.ShowValidation("Choose the club at the top of the form first.", cboClub);
                return;
            }

            int studentId = GetSelectedId(cboStudent);
            if (studentId == 0)
            {
                UiHelper.ShowValidation("Choose the student to add.", cboStudent);
                return;
            }

            string role = cboRole.SelectedItem as string;
            if (role == null)
            {
                UiHelper.ShowValidation("Choose a role for the new member.", cboRole);
                return;
            }

            try
            {
                string clubName = cboClub.Text;
                _memberships.AddStudentToClub(studentId, clubId, role);
                UiHelper.ShowInfo("The student was added to " + clubName + " as " + role + ".");

                cboStudent.SelectedIndex = -1;
                cboRole.SelectedItem = "Member";
                _mode = ViewMode.ClubMembers;
                txtSearch.Clear();
                ClearSelection();
                RefreshGrid();
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex); // 50003 duplicate, 50005 inactive club / role taken
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
        }

        /// <summary>Save Role / Status: needs a selected row, then calls sp_Membership_Update.</summary>
        private void btnUpdateMember_Click(object sender, EventArgs e)
        {
            if (_selectedMembershipId == 0)
            {
                UiHelper.ShowWarning("Click a membership in the list first.");
                return;
            }

            string role = cboEditRole.SelectedItem as string;
            string status = cboEditStatus.SelectedItem as string;
            if (role == null)
            {
                UiHelper.ShowValidation("Choose a role.", cboEditRole);
                return;
            }

            if (status == null)
            {
                UiHelper.ShowValidation("Choose a status.", cboEditStatus);
                return;
            }

            try
            {
                _memberships.Update(_selectedMembershipId, role, status);
                UiHelper.ShowInfo("The membership was updated: role " + role + ", status " + status + ".");
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

        /// <summary>Remove from Club: needs a selected row and a confirmation, then calls sp_Membership_Delete.</summary>
        private void btnRemoveMember_Click(object sender, EventArgs e)
        {
            if (_selectedMembershipId == 0)
            {
                UiHelper.ShowWarning("Click a membership in the list first.");
                return;
            }

            if (!UiHelper.Confirm("Remove this membership?\n\n" + lblSelected.Text + "\n\nThis cannot be undone."))
            {
                return;
            }

            try
            {
                _memberships.Delete(_selectedMembershipId);
                UiHelper.ShowInfo("The member was removed from the club.");
                ClearSelection();
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
    }
}
