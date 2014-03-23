using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Service
{
    public interface IProductImageService
    {
        void CreateProductImage(int ProductId, Image image);
 
        IList<Image> GetProductImages(int ProductId);

        Image GetProductImage(int ImageId);

        void RemoveProductImage(int ProductId, int ImageId);

        void UpdateProductImage(int imageId);


        
        
        


    }
}
