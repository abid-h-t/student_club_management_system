using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StudentClubManagement.DataAccess;
using StudentClubManagement.Utilities;

namespace StudentClubManagement.Forms
{
    /// <summary>
    /// Read-only club summary: one row per club with member counts, event
    /// counts and the next upcoming event (sp_Report_ClubSummary).
    /// </summary>
    public partial class ReportsForm : Form
    {
        private readonly ReportRepository _reports = new ReportRepository();

        public ReportsForm()
        {
            InitializeComponent();
            UiHelper.ConfigureGrid(dgvReport);
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        /// <summary>
        /// Runs sp_Report_ClubSummary (optionally for active clubs only),
        /// shows the rows in the grid and adds up the totals underneath.
        /// </summary>
        private void LoadReport()
        {
            try
            {
                DataTable report = _reports.GetClubSummary(chkActiveOnly.Checked);

                dgvReport.DataSource = report;
                UiHelper.HideColumns(dgvReport, "ClubID");
                UiHelper.SetColumnWeight(dgvReport, 190, "ClubName", "NextEventName");
                UiHelper.SetColumnWeight(dgvReport, 150, "AdvisorName", "NextEventDate");
                if (dgvReport.Columns.Contains("NextEventDate"))
                {
                    dgvReport.Columns["NextEventDate"].DefaultCellStyle.Format = "dd MMM yyyy  HH:mm";
                }

                int activeMembers = 0, events = 0, upcoming = 0;
                foreach (DataRow row in report.Rows)
                {
                    activeMembers += Convert.ToInt32(row["ActiveMembers"]);
                    events += Convert.ToInt32(row["TotalEvents"]);
                    upcoming += Convert.ToInt32(row["UpcomingEvents"]);
                }

                lblTotals.Text = "Totals:  " + report.Rows.Count + " club(s)   |   " + activeMembers +
                                 " active membership(s)   |   " + events + " event(s), of which " +
                                 upcoming + " upcoming";
                lblGenerated.Text = "Generated " + DateTime.Now.ToString("dd MMM yyyy HH:mm:ss");
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void chkActiveOnly_CheckedChanged(object sender, EventArgs e)
        {
            LoadReport();
        }
    }
}
