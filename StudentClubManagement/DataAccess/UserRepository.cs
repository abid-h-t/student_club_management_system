using System;
using System.Data;
using StudentClubManagement.Models;
using StudentClubManagement.Utilities;

namespace StudentClubManagement.DataAccess
{
    /// <summary>Data access for the Users table (stored procedure sp_User_Login).</summary>
    public class UserRepository
    {
        /// <summary>
        /// Checks a username and password. The password is hashed with
        /// SHA-256 here, so only the hash ever travels to SQL Server.
        /// Returns the user on success; sp_User_Login raises error 50006
        /// (a SqlException) when the username or password is wrong.
        /// </summary>
        public User Login(string username, string password)
        {
            DataTable table = DBHelper.ExecuteDataTable("dbo.sp_User_Login",
                DBHelper.Param("@Username", username),
                DBHelper.Param("@PasswordHash", PasswordHasher.Sha256Hex(password)));

            if (table.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = table.Rows[0];
            return new User
            {
                UserID = Convert.ToInt32(row["UserID"]),
                Username = row["Username"] as string,
                Role = row["Role"] as string
            };
        }
    }
}
