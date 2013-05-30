using System.Security.Principal;
using BuyAtYourPrice.Web.Models;

namespace BuyAtYourPrice.Web.Security
{
    public static class UserRoleManager
    {
        public static GenericPrincipal GetGenericPrincipal(dynamic user)
        {
            return new GenericPrincipal((user is CustomerProfile) ? user : new CustomerProfile(user)
                                        , UserRoleManager.GetUserRole(user));
        }

        private static string[] GetUserRole(dynamic user)
        {
            if (user is CustomerProfile)
                return new[] { "ProfiledUser" };

            return new[] { "DefaultUser" };
        }

    }
}