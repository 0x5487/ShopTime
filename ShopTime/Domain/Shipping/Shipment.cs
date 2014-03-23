using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class Shipment
    {
        public int ShipmentId { get; set; }

        public int OrderId { get; set; }

        public string TrackingNumber { get; set; }

        public decimal TotalWeight { get; set; }

        public DateTime ShippedDateUtc { get; set; }

        public DateTime DeliveryDateUtc { get; set; }

        public DateTime CreatedDateUtc { get; set; }
    }
}
