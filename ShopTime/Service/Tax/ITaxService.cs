using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Service
{
    public interface ITaxService
    {
        IShopTimeToken ShopTimeToken { get; set; }
    }
}
