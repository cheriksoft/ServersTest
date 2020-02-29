using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Datalayer.Factories;
using Datalayer.Infrastructure;
using Datalayer.Repositories;
using ServersApp.Infrastructure;
using ServersApp.Models;

namespace ServersApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new WindsorContainer();

            container
                .Register(Types
                    .FromThisAssembly()
                    .BasedOn<IController>()
                    .Configure(c => c.LifestyleTransient())
                )
              .Singleton<IDbContextProvider, PerWebRequestDbContextProvider>()
              .Singleton<IVirtualServerFactory, VirtualServerFactory>()
              .PerRequest<IEntityRepository, EntityRepository>()
              .PerRequest<IVirtualServersModelBuilder, VirtualServersModelBuilder>()
              .PerRequest<ITotalUsageTimeCalculatorService, TotalUsageTimeCalculatorService>()
              .PerRequest<IVirtualServersHandler, VirtualServersHandler>();

            DependencyResolver.SetResolver(
                serviceType => container.Kernel.HasComponent(serviceType) ? container.Resolve(serviceType) : null,
                serviceType => container.ResolveAll(serviceType).Cast<object>());

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }
    }
}
