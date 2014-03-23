using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class Variant
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public int ParentProductId { get; set; }

        public string DisplayName { get; set; }

        [NotMapped]
        public ProductType ProductType { get; set; }

        public ProductStatus ProductStatus { get; set; }      

        public ManageInventoryMethod ManageInventoryMethod { get; set; }

        public int InventoryQuantity { get; set; }

        public string Sku { get; set; }

        public decimal? ListPrice { get; set; }

        public decimal? Price { get; set; }

        public bool IsVisible { get; set; }

        public bool IsPurchasable { get; set; }

        public bool IsBackOrderEnabled { get; set; }

        public bool IsPreOrderEnabled { get; set; }

        public string Tags { get; set; }

        public decimal? Weight { get; set; }

        public WeightUnit WeightUnit { get; set; }

        public bool IsShippingAddressRequired { get; set; }

        public int Position { get; set; }

        public Seo SeoSetting { get; set; }

        public virtual AuditInfo AuditInfo { get; set; }


        #region Nagivations

        public virtual Product ParentProduct { get; set; }
        public virtual ICollection<CustomField> CustomFields { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<VariantOption> VariantOptions { get; set; }


        #endregion

        public Variant() 
        {
            ProductType = ProductType.Variant;
            IsShippingAddressRequired = true;
            ManageInventoryMethod = ManageInventoryMethod.NoTrack;
        }

    }
}
