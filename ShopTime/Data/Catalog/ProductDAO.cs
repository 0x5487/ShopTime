using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Data
{
    //public partial class ShopTimeDbContext 
    //{

        //public IResult<int> CreateProduct(Product product)
        //{
        //    throw new NotImplementedException();
        //}

        //public IResult<Product> GetProduct(int productId)
        //{
        //    throw new NotImplementedException();
        //}

        //public IResult UpdateProduct(Product product)
        //{
        //    throw new NotImplementedException();
        //}

        //public IResult DeleteProduct(int productId)
        //{
        //    throw new NotImplementedException();
        //}

        //public IResult<bool> IsProductExisting(int productId)
        //{
        //    IResult<bool> result = null;

        //    try
        //    {
        //        var answer = this.ProductEntities.Any(obj => obj.Id == productId && obj.StoreId == this._token.Store.StoreId);
        //        result = new ShopTimeResult<bool>(answer);
        //    }
        //    catch (Exception ex)
        //    {
        //        result = new ShopTimeResult<bool> { Error = new Error() { CodeNumber = 500, Message = ex.Message } };
        //    }

        //    return result;
        //}
    //}
}
