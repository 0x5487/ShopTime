using System.Web.Mvc;

namespace JasonSoft.ShopTimeMVC.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_Home",
                "admin",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                name: "EditPage",
                url: "admin/page/edit/{pageName}",
                defaults: new { controller = "Page", action = "Edit" }
            );

            context.MapRoute(
                name: "DisplayTheme",
                url: "admin/theme/{themeName}",
                defaults: new { controller = "Theme", action = "DisplayTheme" }
            );

            context.MapRoute(
                "Admin_Default",
                "admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
