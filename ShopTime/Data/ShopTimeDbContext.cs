using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Data
{
    public class ShopTimeDbContext : DbContext, IDBConetxt
    {
        private IShopTimeToken _token;

        #region Entities

        public IDbSet<Store> Stores { get; set; }
        public IDbSet<Collection> Collections { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<ProductOption> ProductOptions { get; set; }
        public IDbSet<Variant> Variations { get; set; }
        public IDbSet<VariantOption> VariantOptionsOptions { get; set; }
        public IDbSet<Option> Options { get; set; }
        public IDbSet<OptionValue> OptionValues { get; set; }
        public IDbSet<Image> Images { get; set; }
        public IDbSet<CustomField> CustomFields { get; set; }

        #endregion



        public ShopTimeDbContext(IShopTimeToken token) : base("ShopTimeDB")
        {
            _token = token;
        }

        public ShopTimeDbContext(IShopTimeToken token, string nameOrConnectionString): base(nameOrConnectionString)
        {
            _token = token;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Collection.CollectionConfiguration());
        }

    }
}
