using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JasonSoft.ShopTimeMVC.Models
{
    public class ProductsViewModel
    {
        public ProductsViewModel() 
        {
            this.Products = new List<ProductViewModel>();
        }

        public IList<ProductViewModel> Products { get; set; }

    }



}