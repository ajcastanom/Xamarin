using System;

using System.Text.RegularExpressions;

namespace AccenturePeoplePCL.Utils.Validations
{
    public static class Email
    {
        public static bool IsValid(String email)
        {
            String pattern = @"^[a-zA-Z0-9_.+-]+@accenture.com$";

            // Instantiate the regular expression object.
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            // Match the regular expression pattern against a text string.
            Match match = regex.Match(email);

            return match.Success;
        }
    }
}