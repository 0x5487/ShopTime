using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JasonSoft.ShopTimeMVC.Models
{
    public class PaymentMethod: IPaymentMethod
    {
        public string Name { get; set; }

    }
}