using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuyAtYourPrice.Core.Domain
{
    public class ProductDescription : DomainEntity
    {
        public virtual string Description { get; set; }
    }
}