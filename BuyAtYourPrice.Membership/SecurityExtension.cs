using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace BuyAtYourPrice.Membership
{
    public static class SecurityExtension
    {
        public static string GetHashedPassword(string password)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
        }

        public static bool IsValidEmail(string email)
        {
            return SecurityValidation.GetEmailValidationRegex().IsMatch(email);
        }

        public static bool IsValidPassword(string password)
        {
            return SecurityValidation.GetPasswordComplexityRegex().IsMatch(password);
        }

        public static bool IsValidUserName(string userName)
        {
            return SecurityValidation.GetUserNameCheckRegex().IsMatch(userName);
        }
    }
}
