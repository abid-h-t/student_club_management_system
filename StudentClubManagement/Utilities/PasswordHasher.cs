using System.Security.Cryptography;
using System.Text;

namespace StudentClubManagement.Utilities
{
    /// <summary>Hashes passwords so plain text is never stored or sent to the database.</summary>
    public static class PasswordHasher
    {
        /// <summary>
        /// Returns the SHA-256 hash of the text as 64 upper-case hex characters.
        /// This matches how the SQL script stores Users.PasswordHash:
        /// CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'password'), 2).
        /// </summary>
        public static string Sha256Hex(string text)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(text ?? string.Empty));

                StringBuilder hex = new StringBuilder(hash.Length * 2);
                foreach (byte b in hash)
                {
                    hex.Append(b.ToString("X2"));
                }

                return hex.ToString();
            }
        }
    }
}
