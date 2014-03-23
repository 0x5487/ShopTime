using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.Components.EnterpriseLibrary.Unity;
using JasonSoft.ShopTime.Data;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTime.Service;


namespace JasonSoft.ShopTime.Tests
{
    public class UnityConfig
    {
        public UnityContainer Container { get; set; }

        public void RegisterComponents()
        {
            var container = new UnityContainer();

            var store = new Store { DisplayName = "myStore", DomainName = "www.mystore.com", Id = 1 };
            container.RegisterInstance(store);
            
            var token = new ShopTimeToken
            {
                Store = store,
                UserProfile = new ShopTimeUserProfile() { UserId = 1, DisplayName = "Jason Lee" }
            };

            container.RegisterInstance<IShopTimeToken>(token);

            //string connectionstring = string.Format(@"Data Source=(localdb)\v11.0;Initial Catalog={0};Integrated Security=True", Guid.NewGuid());
            string connectionstring = "ShopTimeDb";
            var shopTimeDb = new ShopTimeDbContext(token, connectionstring);
            shopTimeDb.Database.Log = Console.WriteLine;
            container.RegisterInstance(shopTimeDb);
            


            

            #region Repositories

            container.RegisterType<IRepository<Collection>, EfRepository<Collection>>();
            container.RegisterType<IRepository<CustomField>, EfRepository<CustomField>>();

            #endregion



            #region Services

            container.RegisterType<ICollectionService, CollectionService>();
            container.RegisterType<IProductService, ProductService>();


            #endregion

            Container = container;
        }
    }
}
