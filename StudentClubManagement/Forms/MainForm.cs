using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StudentClubManagement.DataAccess;
using StudentClubManagement.Utilities;

namespace StudentClubManagement.Forms
{
    /// <summary>
    /// Dashboard: shows the totals from sp_Dashboard_GetStats and opens every
    /// other form from its buttons and menu.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly ReportRepository _reports = new ReportRepository();

        /// <summary>True when the form was closed with the Log Out button (Program.cs then shows the login form again).</summary>
        public bool LogoutRequested { get; private set; }

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>On start: show which database is used and the statistics.</summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadStats();
        }

        /// <summary>
        /// Calls sp_Dashboard_GetStats and copies its single row into the five
        /// statistic tiles. Called on load, on Refresh and after a child form closes.
        /// </summary>
        private void LoadStats()
        {
            try
            {
                DataTable stats = _reports.GetDashboardStats();
                if (stats.Rows.Count == 0)
                {
                    return;
                }

                DataRow row = stats.Rows[0];
                lblStudentsValue.Text = row["TotalStudents"].ToString();
                lblClubsValue.Text = row["TotalClubs"].ToString();
                lblActiveClubsValue.Text = row["ActiveClubs"].ToString();
                lblMembershipsValue.Text = row["ActiveMemberships"].ToString();
                lblUpcomingValue.Text = row["UpcomingEvents"].ToString();

                SqlConnectionStringBuilder info = new SqlConnectionStringBuilder(DBHelper.GetConnectionString());
                lblStatus.Text = "Connected to " + info.DataSource + " / " + info.InitialCatalog +
                                 "   -   statistics refreshed at " + DateTime.Now.ToString("HH:mm:ss");
            }
            catch (SqlException ex)
            {
                lblStatus.Text = "Not connected to the database";
                UiHelper.ShowSqlError(ex);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Not connected to the database";
                UiHelper.ShowUnexpectedError(ex);
            }
        }

        /// <summary>Opens a child form as a dialog and refreshes the statistics when it closes.</summary>
        private void OpenChildForm(Form child)
        {
            using (child)
            {
                child.ShowDialog(this);
            }

            LoadStats();
        }

        private void btnClubs_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ClubsForm());
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StudentsForm());
        }

        private void btnMemberships_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MembershipsForm());
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EventsForm());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReportsForm());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStats();
        }

        /// <summary>Log Out button: close the dashboard and return to the login form.</summary>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (UiHelper.Confirm("Log out and return to the login screen?"))
            {
                LogoutRequested = true;
                Close();
            }
        }
    }
}
