using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GP.IoC;
using LightInject;

namespace GP.Website
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = new ServiceContainer();
            container.RegisterControllers();
            Container.InitiateContainer(container);
            container.EnableMvc();
        }
    }
}