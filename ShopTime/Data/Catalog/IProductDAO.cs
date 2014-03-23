using System;
using System.Collections.Generic;
using JasonSoft.ShopTime.Domain;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JasonSoft.ShopTime.Data
{
    public interface IProductDAO
    {
        IResult<int> CreateProduct(Product product);

        IResult<Product> GetProduct(int productId);


        IResult UpdateProduct(Product product);

        IResult DeleteProduct(int productId);
    }
}
