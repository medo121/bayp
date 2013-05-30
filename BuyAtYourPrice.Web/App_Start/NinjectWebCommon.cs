using System.Data.Entity;
using BuyAtYourPrice.Domain;
using BuyAtYourPrice.Repository.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

[assembly: WebActivator.PreApplicationStartMethod(typeof(BuyAtYourPrice.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(BuyAtYourPrice.Web.App_Start.NinjectWebCommon), "Stop")]

namespace BuyAtYourPrice.Web.App_Start
{
    using System;
    using System.Web;
    
    using Ninject;
    using Ninject.Web.Common;
    using BuyAtYourPrice.Membership;
    using BuyAtYourPrice.Web.Controllers;
    using BuyAtYourPrice.Repository;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<MembershipContext>().ToSelf().InRequestScope();

            kernel.Bind<IMembershipProvider>().ToMethod(fn =>
            {
                var membershipProvider = (MembershipProvider)System.Web.Security.Membership.Provider;
                membershipProvider.ApplicationName = Configuration.MembershipApplicationName;
                return membershipProvider;
            })
               .InRequestScope();

        }
    }
}
