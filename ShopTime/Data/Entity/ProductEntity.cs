using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Data.Table;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Data
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        public int StoreId { get; set; }

        [Required]
        public string ResourceId { get; set; }

        public bool HasVariations { get; set; }

        public virtual ICollection<ImageEntity> Images { get; set; }

        public ProductType ProductType { get; set; }

        public ProductStatus ProductStatus { get; set; }

        public ManageInventoryMethod ManageInventoryMethod { get; set; }

        public string Sku { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public bool DisplayProduct { get; set; }

        public bool IsPurchasable { get; set; }

        public string Vendor { get; set; }

        public string Description { get; set; }

        public decimal? Weight { get; set; }

        public WeightUnit WeightUnit { get; set; }

        public string Tags { get; set; }

        public int InventoryQuantity { get; set; }

        public bool IsBackOrderEnabled { get; set; }

        public bool IsPreOrderEnabled { get; set; }

        public bool IsShippingAddressRequired { get; set; }

        public decimal? Price { get; set; }

        public bool IsFreeShipping { get; set; }

        public virtual ICollection<MetaDataEntity> MetaData { get; set; }

        public Seo SeoSetting { get; set; }

        public AuditInfo AuditInfo { get; set; }

        

    }
}
