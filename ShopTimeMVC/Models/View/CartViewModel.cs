using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JasonSoft.ShopTimeMVC.Models
{
    public class CartViewModel : ShopTimeViewModel
    {
        public decimal TotalPrice { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Tax { get; set; }

        public decimal ShippingFee { get; set; }

        public IList<LineItem> LineItems { get; set; }

        public CartViewModel() 
        {
            TemplateName = "Cart";
        }

    }

    public class LineItem 
    {
        public int LineItemId { get; set; }

        public string DisplayName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}