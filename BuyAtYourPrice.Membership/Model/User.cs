using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuyAtYourPrice.Membership.Model
{
    public class BusinessUser : System.Web.Security.MembershipUser  
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
    }
}
