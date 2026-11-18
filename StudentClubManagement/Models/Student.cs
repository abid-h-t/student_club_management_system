using System;

namespace StudentClubManagement.Models
{
    /// <summary>One row of the Students table.</summary>
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public int YearOfStudy { get; set; }
        public DateTime CreatedAt { get; set; }

        /// <summary>First and last name joined for display.</summary>
        public string FullName
        {
            get { return (FirstName + " " + LastName).Trim(); }
        }
    }
}
