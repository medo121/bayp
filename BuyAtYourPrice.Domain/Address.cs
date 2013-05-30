using System;
using System.Collections.Generic;

namespace BuyAtYourPrice.Domain
{
    public class Address
    {
        public int Id { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string StateProvince { get; set; }

        public string PostalCode { get; set; }

        public string CountryRegion { get; set; }

        public string AddressLabel { get; set; }

        public ICollection<Customer> Customers { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}