using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using StudentClubManagement.DataAccess;
using StudentClubManagement.Models;
using StudentClubManagement.Utilities;

namespace StudentClubManagement.Forms
{
    /// <summary>
    /// Asks for a username and password and checks them with sp_User_Login.
    /// Closes with DialogResult.OK when the login succeeds.
    /// </summary>
    public partial class LoginForm : Form
    {
        private readonly UserRepository _users = new UserRepository();

        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Login button: validate the two fields, hash the password, call
        /// sp_User_Login and open the main form (via Program.cs) on success.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Validate before touching the database
            if (Validator.IsBlank(txtUsername.Text))
            {
                UiHelper.ShowValidation("Please enter your username.", txtUsername);
                return;
            }

            if (txtPassword.Text.Length == 0)
            {
                UiHelper.ShowValidation("Please enter your password.", txtPassword);
                return;
            }

            // 2. Call the stored procedure
            try
            {
                Cursor = Cursors.WaitCursor;
                User user = _users.Login(txtUsername.Text.Trim(), txtPassword.Text);

                if (user == null)
                {
                    UiHelper.ShowWarning("Invalid username or password.");
                    return;
                }

                // 3. Remember who logged in and let Program.cs open the dashboard
                Session.CurrentUser = user;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex)
            {
                // 50006 = wrong username/password; other numbers = connection problems etc.
                UiHelper.ShowSqlError(ex);
                txtPassword.Clear();
                txtPassword.Focus();
            }
            catch (Exception ex)
            {
                UiHelper.ShowUnexpectedError(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
