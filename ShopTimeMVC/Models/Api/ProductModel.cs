using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTimeMVC.Models;
using Newtonsoft.Json;

namespace JasonSoft.ShopTimeMVC.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Sku { get; set; }

        [Required]
        public string ResourceId { get; set; }

        public string DisplayName { get; set; }

        public bool IsPurchasable { get; set; }   

        public bool IsVisible { get; set; }

        public bool IsBackOrderEnabled { get; set; }

        public bool IsPreOrderEnabled { get; set; }

        public bool IsShippingAddressRequired { get; set; }

        public string Tags { get; set; }

        public decimal? ListPrice { get; set; }

        public decimal? Price { get; set; }

        public string Description { get; set; }

        public string Vendor { get; set; }

        public int InventoryQuantity { get; set; }

        public ManageInventoryMethod ManageInventoryMethod { get; set; }

        public decimal? Weight { get; set; }

        public WeightUnit WeightUnit { get; set; }

        public int OptionListId { get; set; }

        public Seo SeoSetting { get; set; }

        public AuditInfo AuditInfo { get; set; }


        #region Relationship
        public IList<CollectionModel> Collections { get; set; }

        public LinkModel Variations { get; set; }

        public LinkModel Images { get; set; }

        public LinkModel CustomFields { get; set; }

        #endregion
    }
}