using System;

namespace BuyAtYourPrice.Core.Domain
{
    public class CustomerAddress
    {
        public virtual string AddressType { get; set; }

        public virtual Address Address { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual DateTime ModifiedDate { get; set; }
    }
}