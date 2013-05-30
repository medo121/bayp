using System.Data.Entity;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using BuyAtYourPrice.Core.Data;
using BuyAtYourPrice.DataInitializer;
using BuyAtYourPrice.Membership;
using BuyAtYourPrice.Membership.Model;
using BuyAtYourPrice.Repository;
using BuyAtYourPrice.Repository.Interfaces;
using BuyAtYourPrice.Web.App_Start;
using BuyAtYourPrice.Web.Controllers;
using BuyAtYourPrice.Web.Security;
namespace BuyAtYourPrice.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {

        protected void Application_OnPostAuthenticateRequest()
        {
            if ((HttpContext.Current.User.Identity.IsAuthenticated) && (HttpContext.Current.User.Identity.AuthenticationType != "Cutom"))
            {
                ReloadPortalUser();
            }
        }

        public static void SetPortalUser(dynamic user)
        {
            HttpContext.Current.User = UserRoleManager.GetGenericPrincipal(user);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AuthConfig.RegisterAuth();
            
            IContainer container = InitializeContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            Database.SetInitializer(new BuyAtYourPriceDatabaseInitializer());


            // Forces initialization of database on model changes.

            using (var memeberShipContext = new MembershipContext())
            {
                memeberShipContext.Database.Initialize(force: true);
            }

            using (var context = new BuyAtYourPriceCoreDbContext())
            {
                context.Database.Initialize(force: true);
            }

        }

        private void ReloadPortalUser()
        {
            var membership = new MembershipProvider();
            var currentUser = membership.GetUser(HttpContext.Current.User.Identity.Name, true) as BusinessUser;
            dynamic customerProfile = UserManager.GetCustomerProfile(currentUser);
            SetPortalUser(customerProfile);
        }

        private static IContainer InitializeContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BuyAtYourPriceCoreDbContext>().As<DbContext>();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>))
            .WithParameter(ResolvedParameter.ForNamed<DbContext>("BuyAtYourPriceCoreDbContext"));

            builder.RegisterType<AccountController>().InstancePerDependency();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());

            return builder.Build();
        }
    }
}