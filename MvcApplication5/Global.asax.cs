using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;

using MvcApplication5.Models;

namespace MvcApplication5
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

           var builder=RegisterService();
            
           DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        private ContainerBuilder RegisterService()
        {
            var builder = new ContainerBuilder();

           var baseType=typeof(IDependency);
           var assemblys=AppDomain.CurrentDomain.GetAssemblies().ToList();            
           var AllServices = assemblys
               .SelectMany(s => s.GetTypes())
               .Where(p => baseType.IsAssignableFrom(p)&&p!=baseType);

           builder.RegisterControllers(assemblys.ToArray());
        
           builder.RegisterAssemblyTypes(assemblys.ToArray())
                  .Where(t =>baseType.IsAssignableFrom(t)&&t!=baseType)
                  .AsImplementedInterfaces().InstancePerLifetimeScope();
           return builder;
        }
    }
}