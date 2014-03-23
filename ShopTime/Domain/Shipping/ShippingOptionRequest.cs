using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class ShippingOptionRequest
    {
        public IList<LineItem> LineItems { get; set; }

        public ContactInfo Departure { get; set; }

        public ContactInfo Arrival { get; set; }

    }
}
