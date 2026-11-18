using System;

namespace StudentClubManagement.Models
{
    /// <summary>One row of the Clubs table.</summary>
    public class Club
    {
        public int ClubID { get; set; }
        public string ClubName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string AdvisorName { get; set; }
        public DateTime FoundedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
