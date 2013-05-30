using System.Collections.Generic;
using BuyAtYourPrice.Domain;


namespace BuyAtYourPrice.Web.Models
{
    public class CategoryModel
    {
        public IList<ProductCategory> ProductCategories { get; set; }
    }
}