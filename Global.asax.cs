namespace THosCase
{
    using System.Data.Entity;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using THosCase.Data.Context;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<ApplicationDbContext>(null);

            UnityConfig.RegisterComponents();

        }

        protected void Application_BeginRequest()
        {
            Response.ContentEncoding = Encoding.UTF8;
            Response.Charset = "utf-8";
        }
    }
}
