using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JasonSoft.ShopTimeMVC.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }



        public string DisplayName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}