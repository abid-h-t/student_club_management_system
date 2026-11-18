using System;

namespace StudentClubManagement.Models
{
    /// <summary>
    /// One row of the Events table, plus the club name and the number of
    /// registered students that the stored procedures return for display.
    /// </summary>
    public class Event
    {
        public int EventID { get; set; }
        public int ClubID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }

        // Display-only values
        public string ClubName { get; set; }
        public int RegisteredCount { get; set; }
    }
}
