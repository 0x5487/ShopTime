using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class ShippingItem
    {
        public int ShippingItemId { get; set; }

        public int ShipmentId { get; set; }

        public int OrderItemId { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDateUtc { get; set; }
    }
}
