using System.Web;
using System.Web.Mvc;
using JasonSoft.ShopTimeMVC.Filters;

namespace JasonSoft.ShopTimeMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new DesignModeAttribute());
        }
    }
}