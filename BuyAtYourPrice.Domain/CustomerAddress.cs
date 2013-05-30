using System;

namespace BuyAtYourPrice.Domain
{
    public class CustomerAddress
    {
        public  string AddressType { get; set; }

        public  Address Address { get; set; }

        public  Customer Customer { get; set; }

        public  DateTime ModifiedDate { get; set; }
    }
}