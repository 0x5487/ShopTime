using JasonSoft.ShopTime.Data;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTime.Service;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace JasonSoft.ShopTimeMVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IShopTimeToken, ShopTimeToken>();
            container.RegisterType<IDBConetxt, ShopTimeDbContext>();
            container.RegisterType<ICollectionService, CollectionService>();
            container.RegisterType<IProductService, ProductService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}