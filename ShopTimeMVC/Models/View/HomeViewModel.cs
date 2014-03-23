using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTimeMVC.Models
{
    public class HomeViewModel : ShopTimeViewModel
    {
        public HomeViewModel() 
        {

        }

        public IEnumerable<Collection> Collections { get; private set; }


    }
}