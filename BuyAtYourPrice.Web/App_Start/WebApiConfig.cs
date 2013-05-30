using System.Web.Http;

namespace BuyAtYourPrice.Web.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
                name: "CustomerApi",
                routeTemplate: "api/customer/{action}/{username}",
                defaults: new { Controller = "Customer", username = RouteParameter.Optional }
                );
         
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

        }
    }
}