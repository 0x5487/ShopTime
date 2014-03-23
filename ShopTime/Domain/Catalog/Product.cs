using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace JasonSoft.ShopTime.Domain
{
    public class Product
    {

        public int Id { get; set; }

        public int StoreId { get; set; }

        [Required]
        public string ResourceId { get; set; }
        [Required]
        public string DisplayName { get; set; }

        [NotMapped]
        public ProductType ProductType { get; set; }

        public ProductStatus ProductStatus { get; set; }        

        public ManageInventoryMethod ManageInventoryMethod { get; set; }

        public string Sku { get; set; }

        public bool IsVisible { get; set; }

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

        public decimal? ListPrice { get; set; }
        
        public Seo SeoSetting { get; set; }

        public virtual AuditInfo AuditInfo { get; set; }

        #region Nagivations

        public virtual ICollection<Collection> Collections { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<ProductOption> ProductOptions { get; set; }
        public virtual ICollection<Variant> Variations { get; set; }
        public virtual ICollection<CustomField> CustomFields { get; set; }

        #endregion


        public Product()
        {
            ProductType = ProductType.Product;
            IsShippingAddressRequired = true;
            ManageInventoryMethod = ManageInventoryMethod.NoTrack;
        }
        
    }
    
}



//public bool IsCallForPriceEnabled { get; set; }
//public int VersionId { get; set; }
//public ProductVersionStatus ProductVersionStatus { get; set; }
//public LowStockAction LowStockAction { get; set; }
//public bool DisplayInventoryQuantity { get; set; }
//public int MinimumCartQuantity { get; set; }
//public int MaximumCartQuantity {get; set;}
//public int MinimumStockQuantity {get; set;}
//public bool IsNotificationEnabled { get; set; }
//public bool DisplayWhenOutOfStock { get; set; }
//public string ExternalId { get; set; }
//public decimal? ActualPrice { get; set; }
//public decimal? ActualPriceWithTax { get; set; }
//public decimal? RegularPrice { get; set; }
//public decimal? RegularPriceWithTax { get; set; }
//public decimal? YouSave { get; set; }
//public decimal? Discount { get; set; }
//public bool TaxExempt { get; set; }
//public int TaxCategory { get; set; }                      
//public int LowStockLevel { get; set; }
//public bool IsDownloadable { get; set; }
//public bool IsReturnable { get; set; }
//public bool IsCancelable { get; set; }
//public Dictionary<string, string> ProductAttributes { get; set; }
//public DateTime StartDate { get; set; }
//public DateTime? EndDate { get; set; } 
//public bool IsProductDiscounted { get; set; }