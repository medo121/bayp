using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuyAtYourPrice.Core.Domain
{
    public class ProductModel : DomainEntity
    {
        public virtual string Name { get; set; }
    }
}