using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTimeMVC.Models
{
    public class CollectionViewModel : ShopTimeViewModel
    {

        public Collection Collection { get; set; }

        public CollectionViewModel() 
        {
            Collection = new Collection();
            TemplateName = "Collection";
        }


    }
}