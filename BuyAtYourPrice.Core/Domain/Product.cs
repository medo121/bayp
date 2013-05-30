using System;
using System.Collections.Generic;

namespace BuyAtYourPrice.Core.Domain
{
    public class Product : DomainEntity
    {
        public virtual string Name { get; set; }

        public virtual string ProductNumber { get; set; }

        public virtual string Color { get; set; }

        public virtual double StandardCost { get; set; }

        public virtual double ListPrice { get; set; }

        public virtual string Size { get; set; }

        public virtual decimal Weight { get; set; }

        public virtual ProductCategory Category { get; set; }

        public virtual ProductModel Model { get; set; }

        public virtual byte[] ThumbNailPhoto { get; set; }

        public virtual string ThumbnailPhotoFileName { get; set; }


    }
}