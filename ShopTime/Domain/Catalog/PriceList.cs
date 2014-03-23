using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class PriceList
    {
        public int PriceListId { get; set; }

        public int CatalogId { get; set; }

        public PriceType PriceType { get; set; }

        public string DefaultCurrency { get; set; }

        public DateTime StartDateUtc { get; set; }

        public DateTime? EndDateUtc { get; set; }

        public PriceListStatus PriceListStatus { get; set; }

    }
}
