using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTimeMVC.Models
{
    public class ProductDetailViewModel : ShopTimeViewModel
    {
        public int ProductId { get; set; }

        [DisplayName("品名")]
        public string DisplayName { get; set; }

        public string Description { get; set; }

        [DisplayName("定價")]
        public decimal Price { get; set; }


        public Collection ParentCollection { get; set; }  


        public ProductDetailViewModel() {
            TemplateName = "Product";
        }

        

    }
}