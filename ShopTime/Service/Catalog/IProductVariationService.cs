using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Service
{
    public interface IProductVariationService
    {
        ProductVariationServiceResult CreateProductVariation(int productId, Variant variant);

        IList<Variant> GetProductVariations(int productId);

        ProductVariationServiceResult RemoveProductVariation(int variationId);

    }
}
