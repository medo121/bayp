using System.Collections.Specialized;
using System.Web.Security;

namespace BuyAtYourPrice.Membership
{
    public interface IMembershipProvider
    {
        string ProviderName { get; }

        string ApplicationName { get; set; }

        bool IsUserInRole(string username, string rolename);

        bool ValidateUser(string userName, string password);

        MembershipUser GetUser(string userName, bool userIsOnline);

        MembershipUser GetUser(int userid, bool userIsOnline);

        MembershipUser CreateUser(string username, string password, string email, out MembershipCreateStatus status, string fullname);

        bool ChangePassword(string userName, string oldPassword, string newPassword, bool isResetPassword);

        void Initialize(string name, NameValueCollection config);
    }
}
