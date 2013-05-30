using System;
using System.Collections.Generic;
namespace BuyAtYourPrice.Core.Domain
{
    public class Customer
    {
        public int Id { get; set; }

        public Guid CustomerGuid { get; set; }

        public string Username { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public string EmailAddress { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}