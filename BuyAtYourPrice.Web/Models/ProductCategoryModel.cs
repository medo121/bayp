using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages.Html;

namespace BuyAtYourPrice.Web.Models
{
    public class ProductCategoryModel
    {
        public string search { get; set; }

        public int CategoryId { get; set; }

        public List<SelectListItem> CategoryItems
        {
            get { return GetCategoryItems(); }
            set { CategoryItems = value; }
        }

        private List<SelectListItem> GetCategoryItems()
        {
            var list = new List<SelectListItem>()
                {
                    new SelectListItem {Text = "All Categories", Value = ""},
                    new SelectListItem {Text = "Cameras & Photography", Value = ""},
                    new SelectListItem {Text = "Computers/Tablets & Networking", Value = ""},
                    new SelectListItem {Text = "DVDs, Films & TV", Value = ""},
                    new SelectListItem {Text = "Mobile Phones & Communication", Value = ""},
                    new SelectListItem {Text = "Musical Instruments", Value = ""},
                    new SelectListItem {Text = "Sound & Vision", Value = ""},
                    new SelectListItem {Text = "Video Games & Consoles", Value = ""},
                    new SelectListItem {Text = "Everything Else", Value = ""},
                };

            return list;
        }
    }
}