using System.Globalization;
using System.Text.RegularExpressions;

namespace StudentClubManagement.Utilities
{
    /// <summary>
    /// Input checks the forms run BEFORE calling the database. The stored
    /// procedures repeat the important ones, so the rules hold even if
    /// another program uses the database.
    /// </summary>
    public static class Validator
    {
        private static readonly Regex EmailPattern =
            new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        private static readonly Regex PhonePattern =
            new Regex(@"^[0-9+\-() ]{7,20}$", RegexOptions.Compiled);

        /// <summary>True when the text is null, empty or only spaces.</summary>
        public static bool IsBlank(string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        /// <summary>True for addresses shaped like name@domain.tld (no spaces, one @).</summary>
        public static bool IsValidEmail(string email)
        {
            return !IsBlank(email) && EmailPattern.IsMatch(email.Trim());
        }

        /// <summary>True for 7-20 digits, optionally with + - ( ) and spaces.</summary>
        public static bool IsValidPhone(string phone)
        {
            return !IsBlank(phone) && PhonePattern.IsMatch(phone.Trim());
        }

        /// <summary>Parses a whole number that must lie between min and max (inclusive).</summary>
        public static bool TryParseIntInRange(string text, int min, int max, out int value)
        {
            bool ok = int.TryParse((text ?? string.Empty).Trim(), NumberStyles.None,
                                   CultureInfo.InvariantCulture, out value);
            return ok && value >= min && value <= max;
        }
    }
}
