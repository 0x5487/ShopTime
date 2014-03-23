using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Service
{
    public static partial class ShoppingCartExtension
    {
        public static Boolean IsShippingRequired(this IEnumerable<LineItem> source)
        {
            throw new NotImplementedException();
        }

        public static decimal GetShoppingCartTotalWeight(this IEnumerable<LineItem> source)
        {
            throw new NotImplementedException();
        }


    }
}
