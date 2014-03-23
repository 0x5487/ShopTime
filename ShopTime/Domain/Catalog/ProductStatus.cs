using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JasonSoft.ShopTime.Domain
{
    public enum ProductStatus
    {
        InStock = 1,
        OutOfStock = 2,
        PreOrder = 3,
        BackOrder = 4,
        NotPurchasable = 5,
        NotAvailable = 6,
        
    }
}
