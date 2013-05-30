using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BuyAtYourPrice.Membership
{
    public static class SecurityValidation
    {

        #region Private Statics

        /// <summary>
        /// Gets the email validation regex.
        /// </summary>
        /// <returns></returns>
        public static Regex GetEmailValidationRegex()
        {
            return new Regex(@"^[a-z0-9_\-]+(\.[_a-z0-9\-]+)*@([_a-z0-9\-]+\.)+([a-z]{2}|aero|arpa|biz|com|coop|edu|gov|info|int|jobs|mil|museum|name|nato|net|org|pro|travel)$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Gets the password complexity regex.
        /// </summary>
        /// <returns></returns>
        /// <remarks>8-50 characters, at least on capital letter, at least one numeral, at least one special character.</remarks>
        public static Regex GetPasswordComplexityRegex()
        {
            return new Regex(@"(?=^.{8,50}$)((?=.*\d)(?=.*[A-Z])(?=.*[a-z])|(?=.*\d)(?=.*[^A-Za-z0-9])(?=.*[a-z])|(?=.*[^A-Za-z0-9])(?=.*[A-Z])(?=.*[a-z])|(?=.*\d)(?=.*[A-Z])(?=.*[^A-Za-z0-9]))^.*", RegexOptions.None);
        }

        /// <summary>
        /// Gets the user name check regex.
        /// </summary>
        /// <returns></returns>
        /// <remarks>No whitespace allowed.</remarks>
        public static Regex GetUserNameCheckRegex()
        {
            return new Regex(@"^[\S]*$", RegexOptions.IgnoreCase);
        }

        #endregion
    }
}
