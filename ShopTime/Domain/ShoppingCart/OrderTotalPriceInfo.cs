using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class OrderTotalPriceInfo
    {

        public decimal SubTotal { get; set; }

        public decimal Tax { get; set; }

        public decimal Shipping { get; set; }

        public decimal Total { get; set; }

    }
}
