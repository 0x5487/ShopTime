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
    public class CollectionModel
    {

        public int Id { get; set; }

        [Required]
        public string ResourceId { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public bool IsVisible { get; set; }

        public string Description { get; set; }

        public ImageModel Image { get; set; }

        public Seo SeoSetting { get; set; }

        public string Tags { get; set; }

        public AuditInfo AuditInfo { get; set; }

        #region Relationship 

        public IList<ProductModel> Products { get; set; }

        public LinkModel CustomFields { get; set; }

        #endregion

        

        public CollectionModel()
        {

        }

        public CollectionModel(string displayName, string resourceId)
        {
            DisplayName = displayName;
            ResourceId = resourceId;
        }
    }

}