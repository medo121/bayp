using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuyAtYourPrice.Web.Models;
using System.Net;

namespace BuyAtYourPrice.Web.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult Products()
        {
            //var searchTerm = "iphone 4";
            //using (var web = new WebClient())
            //{
            //    //    web.Headers.Add("Referrer", "http://your-website-here/");
            //    var result = web.DownloadString(String.Format(
            //           "https://www.googleapis.com/shopping/search/v1/public/products?key=AIzaSyDgltk9NBu-N7kn0MZKmaCtYk5CXE4Lh1c&country=US&q={0}&categories.enabled=true",
            //           searchTerm));
            //}

            var model = new ProductCategoryModel();
            return View(model);
        }
    }
}