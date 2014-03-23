using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft;

namespace JasonSoft.ShopTime.Domain
{
    public class ProductPrice
    {
        public int PriceId { get; set; }

        public int PriceListId { get; set; }

        public int ProductId { get; set; }       

        public string Locale { get; set; }        

        public string Currency { get; set; }

        public decimal? Value { get; set; }

        public bool AllowZero { get; set; }

        public ObjectStatus ObjectStatus { get; set; }
    }
}
