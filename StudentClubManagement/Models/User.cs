namespace StudentClubManagement.Models
{
    /// <summary>
    /// A logged-in application user. The password hash is never loaded into
    /// the application - sp_User_Login only returns the columns below.
    /// </summary>
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
