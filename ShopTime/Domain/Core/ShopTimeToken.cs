using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class ShopTimeToken : IShopTimeToken
    {
        public Company Company { get; set; }
        public Store Store { get; set; }
        public ShopTimeUserProfile UserProfile { get; set; }
        public Shopper CurrentShopper { get; set; }
        public Order CurrentOrder { get; set; }

        public ShopTimeToken()
        {
        }
    }
}
