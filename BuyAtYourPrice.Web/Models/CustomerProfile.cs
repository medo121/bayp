using System.Security.Principal;
using BuyAtYourPrice.Membership.Model;

namespace BuyAtYourPrice.Web.Models
{
    public class CustomerProfile : IIdentity
    {
        private readonly BusinessUser _user;

        public CustomerProfile(BusinessUser user)
        {
            _user = user;
        }

        public string CustomerGuid
        {
            get { return null; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public string Name
        {
            get { return _user.Username; }
        }

        public string Email
        {
            get { return _user.EmailAddress; }
        }

        public string Address { get; set; }
    }
}