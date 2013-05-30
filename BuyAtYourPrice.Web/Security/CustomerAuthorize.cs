using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BuyAtYourPrice.Web.Security
{
    public class CustomerAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                redirectTargetDictionary.Add("action", "Profile");
                redirectTargetDictionary.Add("controller", "Account");
            }
            else
            {

                redirectTargetDictionary.Add("action", "Login");
                redirectTargetDictionary.Add("controller", "Account");
            }

            filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
        }
    }
}