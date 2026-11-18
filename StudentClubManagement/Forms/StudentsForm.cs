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
    /// Add, edit, delete and search students. Selecting a student also lists
    /// the clubs they belong to (sp_Membership_GetClubsByStudent).
    /// </summary>
    public partial class StudentsForm : Form
    {
        private readonly StudentRepository _students = new StudentRepository();
        private readonly MembershipRepository _memberships = new MembershipRepository();

        /// <summary>ID of the student loaded into the fields (0 = none, i.e. "new student" mode).</summary>
        private int _selectedStudentId;

        public StudentsForm()
        {
            InitializeComponent();
            UiHelper.ConfigureGrid(dgvStudents);
            UiHelper.ConfigureGrid(dgvStudentClubs);
        }

        private void StudentsForm_Load(object sender, EventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        // ------------------------------------------------------------------
        // Grid loading
        // ------------------------------------------------------------------

        /// <summary>
        /// Reloads the grid: sp_Student_Search when the search box has text,
        /// otherwise sp_Student_GetAll. Called after every change.
        /// </summary>
        private void RefreshGrid()
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                DataTable table = keyword.Length > 0 ? _students.Search(keyword) : _students.GetAll();

                dgvStudents.DataSource = table;
                UiHelper.HideColumns(dgvStudents, "CreatedAt");
                UiHelper.SetColumnWeight(dgvStudents, 60, "StudentID", "YearOfStudy");
                UiHelper.SetColumnWeight(dgvStudents, 170, "Email", "Department");
                lblCount.Text = table.Rows.Count + (table.Rows.Count == 1 ? " student" : " students") +
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
        /// Clicking a grid row loads that student (fresh from
        /// sp_Student_GetByID) into the fields and lists their clubs.
        /// </summary>
        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return; // header row
            }

            try
            {
                int studentId = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["StudentID"].Value);
                Student student = _students.GetById(studentId);

                if (student == null)
                {
                    UiHelper.ShowWarning("This student no longer exists. The list will be refreshed.");
                    ClearFields();
                    RefreshGrid();
                    return;
                }

                _selectedStudentId = student.StudentID;

                txtStudentId.Text = student.StudentID.ToString();
                txtFirstName.Text = student.FirstName;
                txtLastName.Text = student.LastName;
                txtEmail.Text = student.Email;
                txtPhone.Text = student.Phone ?? string.Empty;
                cboDepartment.Text = student.Department;
                nudYear.Value = Math.Max(nudYear.Minimum, Math.Min(nudYear.Maximum, student.YearOfStudy));

                // Second grid: the clubs this student belongs to
                dgvStudentClubs.DataSource = _memberships.GetClubsByStudent(student.StudentID);
                UiHelper.HideColumns(dgvStudentClubs, "MembershipID", "StudentID", "StudentName", "Email", "ClubID");
                lblStudentClubs.Text = "Club memberships of " + student.FullName + " (" +
                                       dgvStudentClubs.Rows.Count + "):";
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
        /// Checks the fields before any database call: names, email and
        /// department are required, the email must look like an email
        /// address, the phone (optional) may only contain phone characters,
        /// and the year must be 1-6. Returns null when something is invalid.
        /// </summary>
        private Student ReadAndValidateFields()
        {
            if (Validator.IsBlank(txtFirstName.Text))
            {
                UiHelper.ShowValidation("First name is required.", txtFirstName);
                return null;
            }

            if (Validator.IsBlank(txtLastName.Text))
            {
                UiHelper.ShowValidation("Last name is required.", txtLastName);
                return null;
            }

            if (Validator.IsBlank(txtEmail.Text))
            {
                UiHelper.ShowValidation("Email is required.", txtEmail);
                return null;
            }

            if (!Validator.IsValidEmail(txtEmail.Text))
            {
                UiHelper.ShowValidation("Email address is not in a valid format.\n\nExample: name@university.edu", txtEmail);
                return null;
            }

            if (!Validator.IsBlank(txtPhone.Text) && !Validator.IsValidPhone(txtPhone.Text))
            {
                UiHelper.ShowValidation("Phone may only contain digits, spaces and + - ( ), and must be 7 to 20 characters long.\n\nLeave it empty if unknown.", txtPhone);
                return null;
            }

            if (Validator.IsBlank(cboDepartment.Text))
            {
                UiHelper.ShowValidation("Department is required. Choose one from the list or type your own.", cboDepartment);
                return null;
            }

            int year = (int)nudYear.Value;
            if (year < 1 || year > 6)
            {
                UiHelper.ShowValidation("Year of study must be between 1 and 6.", nudYear);
                return null;
            }

            return new Student
            {
                StudentID = _selectedStudentId,
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Department = cboDepartment.Text.Trim(),
                YearOfStudy = year
            };
        }

        // ------------------------------------------------------------------
        // Buttons
        // ------------------------------------------------------------------

        /// <summary>Add: validate, call sp_Student_Insert, show the new ID, refresh the grid.</summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student student = ReadAndValidateFields();
            if (student == null)
            {
                return;
            }

            try
            {
                int newId = _students.Insert(student);
                UiHelper.ShowInfo("Student \"" + student.FullName + "\" was registered with ID " + newId + ".");
                ClearFields();
                RefreshGrid();
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex); // e.g. 50003: email already used
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
        }

        /// <summary>Update: needs a selected student, validates, then calls sp_Student_Update.</summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedStudentId == 0)
            {
                UiHelper.ShowWarning("Click a student in the list first, then change their details and press Update.");
                return;
            }

            Student student = ReadAndValidateFields();
            if (student == null)
            {
                return;
            }

            try
            {
                _students.Update(student);
                UiHelper.ShowInfo("Student \"" + student.FullName + "\" was updated.");
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
        /// Delete: needs a selected student and a confirmation, then calls
        /// sp_Student_Delete (which refuses if the student has memberships
        /// or event registrations).
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedStudentId == 0)
            {
                UiHelper.ShowWarning("Click a student in the list first, then press Delete.");
                return;
            }

            string name = (txtFirstName.Text + " " + txtLastName.Text).Trim();
            if (!UiHelper.Confirm("Delete the student \"" + name + "\"?\n\nThis cannot be undone."))
            {
                return;
            }

            try
            {
                _students.Delete(_selectedStudentId);
                UiHelper.ShowInfo("The student was deleted.");
                ClearFields();
                RefreshGrid();
            }
            catch (SqlException ex)
            {
                UiHelper.ShowSqlError(ex); // e.g. 50004: student still has memberships
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

        /// <summary>Empties the detail fields and returns to "new student" mode.</summary>
        private void ClearFields()
        {
            _selectedStudentId = 0;

            txtStudentId.Text = "(new)";
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            cboDepartment.SelectedIndex = -1;
            cboDepartment.Text = string.Empty;
            nudYear.Value = 1;

            dgvStudentClubs.DataSource = null;
            lblStudentClubs.Text = "Club memberships of the selected student:";

            dgvStudents.ClearSelection();
            txtFirstName.Focus();
        }

        /// <summary>Search: runs sp_Student_Search with the text in the search box.</summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Validator.IsBlank(txtSearch.Text))
            {
                UiHelper.ShowValidation("Type part of a name, email, phone number or department to search for.", txtSearch);
                return;
            }

            RefreshGrid();
        }

        /// <summary>Show All: clears the search box and lists every student again.</summary>
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
