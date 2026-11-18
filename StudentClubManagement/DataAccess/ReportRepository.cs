using System.Data;

namespace StudentClubManagement.DataAccess
{
    /// <summary>Data access for the read-only report and dashboard procedures.</summary>
    public class ReportRepository
    {
        /// <summary>
        /// One row per club with member counts, event counts and the next
        /// upcoming event. Pass true to leave out inactive clubs.
        /// </summary>
        public DataTable GetClubSummary(bool activeOnly)
        {
            return DBHelper.ExecuteDataTable("dbo.sp_Report_ClubSummary",
                DBHelper.Param("@ActiveOnly", activeOnly));
        }

        /// <summary>
        /// A single row with the dashboard totals: TotalStudents, TotalClubs,
        /// ActiveClubs, ActiveMemberships and UpcomingEvents.
        /// </summary>
        public DataTable GetDashboardStats()
        {
            return DBHelper.ExecuteDataTable("dbo.sp_Dashboard_GetStats");
        }
    }
}
