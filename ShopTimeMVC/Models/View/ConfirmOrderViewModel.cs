using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JasonSoft.ShopTimeMVC.Models
{
    public class ConfirmOrderViewModel
    {
        public bool IsShippingRequired { get; set; }

        public int SelectedShippingOptionId { get; set; }
        
        public IList<ShippingOption> ShippingOptions { get; set; }

        public IList<LineItem> LineItems { get; set; }

        public decimal Discount { get; set; }

        public decimal Tax { get; set; }

        public decimal ShippingFee { get; set; }

        public decimal TotalPrice { get; set; }


        public ConfirmOrderViewModel()
        {
            ShippingOptions = new List<ShippingOption>();
            LineItems = new List<LineItem>();
        }        

    }
}