using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{

    public class ShippingOption
    {
        public string ShippingOptionId { get; set; }

        public int ShippingProviderId { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public decimal Rate { get; set; }

    }
}
