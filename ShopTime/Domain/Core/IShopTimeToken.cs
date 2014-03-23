using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public interface IShopTimeToken
    {
        Company Company { get; set; }

        Store Store { get; set; }

        ShopTimeUserProfile UserProfile { get; set; }

        Shopper CurrentShopper { get; set; }

        Order CurrentOrder { get; set; }
    }
}
