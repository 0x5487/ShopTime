using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using System.Globalization;
using System.Threading;
using JasonSoft.ShopTimeMVC;
using JasonSoft;

namespace JasonSoft.ShopTimeMVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.Configure();

            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents(); 
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //DependencyResolver.SetResolver(new NinjectDependencyResolver());
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new MyRazorViewEngine());

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredIfAttribute), typeof(RequiredAttributeAdapter));


            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("preview")
            {
                ContextCondition = (context => context.Session["preview"] != null && 
                                                context.Session["preview"].ToString() == "on")
            });

            //support json media type only
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {


        }
    }
}