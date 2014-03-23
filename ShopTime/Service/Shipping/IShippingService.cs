using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTime.PlugIn;

namespace JasonSoft.ShopTime.Service
{
    public interface IShippingService
    {
        IShopTimeToken ShopTimeToken { get; set; }



        IList<ShippingProvider> GetShippingProviders();

        IList<ShippingOption> GetShippingOptions(ShippingOptionRequest shippingOptionRequest);



    }
}
