using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace SeeSharpRun.Broadcast.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(ApiRegister);
            InitializeUnityContainer();
        }

        private void InitializeUnityContainer()
        {
            var container = new UnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Web", action = "List" }
            );

            routes.MapRoute(
                name: "WebinarLink",
                url: "{slug}",
                defaults: new { controller = "Web", action = "Link", slug = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DownloadLink",
                url: "download/{slug}",
                defaults: new { controller = "Web", action = "Download", slug = UrlParameter.Optional }
            );
        }

        public static void ApiRegister(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{id}",
                defaults: new { controller = "Data", id = RouteParameter.Optional }
            );
        }
    }
}
