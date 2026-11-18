using System;

namespace StudentClubManagement.Models
{
    /// <summary>
    /// One row of the Memberships table, plus the student and club names
    /// that the stored procedures return for display.
    /// </summary>
    public class Membership
    {
        /// <summary>Roles allowed by the CK_Memberships_Role constraint.</summary>
        public static readonly string[] Roles =
            { "Member", "President", "Vice President", "Secretary", "Treasurer" };

        /// <summary>Statuses allowed by the CK_Memberships_Status constraint.</summary>
        public static readonly string[] Statuses = { "Active", "Inactive" };

        public int MembershipID { get; set; }
        public int StudentID { get; set; }
        public int ClubID { get; set; }
        public string Role { get; set; }
        public DateTime JoinDate { get; set; }
        public string Status { get; set; }

        // Display-only values (joined from Students and Clubs)
        public string StudentName { get; set; }
        public string ClubName { get; set; }
    }
}
