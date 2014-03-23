using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.PlugIn
{
    public interface IShippingProvider
    {
        string Name { get; set; }

        string DisplayName { get; set; }        

        IList<ShippingOption> GetShippingOptions();        
        
        IList<ShippingOption> GetShippingOptions(ShippingOptionRequest shippingMethodRequest);       

        
    }
}
