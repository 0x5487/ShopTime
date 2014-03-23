using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Data;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Tests
{
    //DropCreateDatabaseAlways<ShopTimeRepository>
    public class TestDbInitializer : DropCreateDatabaseAlways<ShopTimeDbContext>
    {
        protected override void Seed(ShopTimeDbContext context)
        {
            //Stores
            #region Stores

            var myStore = new Store() {DisplayName = "myStore", DomainName = "www.mystore.com"};
            context.Stores.Add(myStore);

            var myShoe = new Store() { DisplayName = "myShoe", DomainName = "www.myshore.com" };
            context.Stores.Add(myShoe);
            context.SaveChanges();

            #endregion

            #region Collections

            //Collections
            var menCollection = new Collection
            {
                StoreId = myStore.Id,
                DisplayName = "DisplayName_Men",
                ResourceId = "men",
                Tags = new List<string>() { "shirt_tee, long_tee, polo, jeans, underwear, 領帶" },
                AuditInfo = new AuditInfo(),
                
            };
            context.Collections.Add(menCollection);

            var womenCollection = new Collection
            {
                StoreId = myStore.Id,
                DisplayName = "DisplayName_Women",
                ResourceId = "women",
                Tags = new List<string>() { "shirt_tee, long_tee, polo, jeans, underwear, T-Bra" },
                AuditInfo = new AuditInfo(),
            };
            context.Collections.Add(womenCollection);

            var kidsCollection = new Collection
            {
                StoreId = myStore.Id,
                DisplayName = "DisplayName_Kids",
                ResourceId = "kids",
                Tags = new List<string>() { "shirt_tee, long_tee, polo, jeans, heatup," },
                AuditInfo = new AuditInfo(),
            };
            context.Collections.Add(kidsCollection);


            var sportShoesCollection = new Collection
            {
                StoreId = myShoe.Id,
                DisplayName = "DisplayName_sportShoes",
                ResourceId = "sportShoes",
                Tags = new List<string>() { "Nike, reebok, adidas" },
                AuditInfo = new AuditInfo(),
            };
            context.Collections.Add(sportShoesCollection);

            var leatherShoe = new Collection
            {
                StoreId = myShoe.Id,
                DisplayName = "DisplayName_leatherShoe",
                ResourceId = "leatherShoe",
                Tags = new List<string>() { "Accessories, boot, loafer," },
                AuditInfo = new AuditInfo(),
            };
            context.Collections.Add(leatherShoe);
            context.SaveChanges();

            #endregion

            #region CustomFields

            var customField1 = new CustomField()
            {
                StoreId = myStore.Id,
                Type = CustomFieldType.Collection,
                ParentId = menCollection.Id,
                Key = "Jason.ABC",
                Value = "Hell World",
                AuditInfo = new AuditInfo(),
            };
            context.CustomFields.Add(customField1);
            context.SaveChanges();

            #endregion


            //Products


            base.Seed(context);
        }
    }
}
