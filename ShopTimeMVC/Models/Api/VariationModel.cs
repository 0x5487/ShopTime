using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTimeMVC.Models
{
    public class VariationModel
    {

        public int Id { get; set; }

        public string Sku { get; set; }

        public string DisplayName { get; set; }

        public bool IsPurchasable { get; set; }

        public bool IsVisible { get; set; }

        public bool IsBackOrderEnabled { get; set; }

        public bool IsPreOrderEnabled { get; set; }

        public bool IsShippingAddressRequired { get; set; }

        public string Tags { get; set; }

        public decimal? ListPrice { get; set; }

        public decimal? Price { get; set; }

        public int InventoryQuantity { get; set; }

        public ManageInventoryMethod ManageInventoryMethod { get; set; }

        public int Position { get; set; }

        public decimal? Weight { get; set; }

        public WeightUnit WeightUnit { get; set; }

        public Seo SeoSetting { get; set; }

        public AuditInfo AuditInfo { get; set; }

        #region Relationship

        public IList<VariantOption> Options { get; set; }

        public LinkModel Images { get; set; }

        public LinkModel CustomFields { get; set; }

        #endregion
    }
}