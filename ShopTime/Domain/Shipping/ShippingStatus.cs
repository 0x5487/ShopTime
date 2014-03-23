using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public enum ShippingStatus
    {
        NoRequired = 1,
        Delivered = 2,
        PartiallyShipped = 3,
        NotShippedYet = 4,
    }
}
