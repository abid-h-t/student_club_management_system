using StudentClubManagement.Models;

namespace StudentClubManagement.Utilities
{
    /// <summary>Remembers who is logged in while the application is running.</summary>
    public static class Session
    {
        /// <summary>The user returned by sp_User_Login, or null before login.</summary>
        public static User CurrentUser { get; set; }
    }
}
