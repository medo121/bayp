using System.Net.Http;
using System.Web.Mvc;
using BuyAtYourPrice.Web.Models;
using BuyAtYourPrice.Web.Security;

namespace BuyAtYourPrice.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var client = new HttpClient();
            var result = client.GetAsync("http://localhost:21680/api/productcategory/get",
                                         HttpCompletionOption.ResponseContentRead);

            object responseObject;
            result.Result.TryGetContentValue(out responseObject);
            //var categories =
            //    JsonConvert.DeserializeObject<List<ProductCategory>>(result.Result.Content.ReadAsStringAsync().Result);

            var categoryModel = new CategoryModel();
            //categoryModel.ProductCategories = categories;
            return View(categoryModel);
        }

        public ActionResult AddBid()
        {
            return View(@"~/Views/Bids/Add.cshtml");

        }

        [CustomerAuthorize(Roles = "ProfiledUser")]
        public ActionResult AddOffer()
        {
            return View(@"~/Views/Offers/Add.cshtml");

        }
    }
}