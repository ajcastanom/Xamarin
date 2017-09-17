using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using System.Text.RegularExpressions;

namespace AccenturePeople.android.Utils.Validations
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