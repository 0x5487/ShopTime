using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Service
{
    public interface IPriceService
    {
        //CatalogResult CreatePriceList(PriceList priceList);

        PriceList GetPriceList(int priceListId);

        IList<PriceList> GetPriceLists();

        IList<ProductPrice> GetProductPrices(int priceListId, string currency);

        IList<ProductPrice> GetProductPrices(int productId);

        void UpdateProductPrices(IList<ProductPrice> productPrices);

    }
}
