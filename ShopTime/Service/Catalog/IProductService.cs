using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Service
{
    public interface IProductService
    {
        ProductServiceResult CreateProduct(Product product);
        ProductServiceResult CreateProduct(Product product, int[] collectionIds);
        //ProductServiceResult CreateProduct(Product product, IList<Image> images,  int[] collectionIds);


        ProductServiceResult UpdateProduct(Product product);

        Product GetProduct(int productId);
        Product GetProduct(string resourceId);
        ProductServiceResult RemoveProducts(IList<int> productIds);

        int GetCountOfProducts(int collectionId, string filterByTag = null);
        IList<Product> GetProductsByCollection(int collectionId, string filterByTag = null, int pageSize = ShopTimeSetting.PageSize, int pageIndex = 0, CatalogSortBy sortBy = CatalogSortBy.DiplayNameAsc);

        IList<Product> GetProducts(int pageSize = ShopTimeSetting.PageSize, int pageIndex = 0, CatalogSortBy sortBy = CatalogSortBy.DiplayNameAsc);

        IList<Image> GetProductImages(int productId);
    }
}


//void CreateAndDeployProduct(Product product);
//CatalogResult DeployPrduct(int productId);
//void UpdateAndDeployProduct(Product product);
//Product GetPushlishedProduct(int product);
//Dictionary<int, string> GetProductAttributes();
//Dictionary<int, string> GetProductAttributeValues(int productAttributeId);
//void UpdateProductInvertory(int productId, int newInvertory);
//void DecreaseProductInvertory(int productId, int number);
//void IncreaseProductInvertory(int productId, int number);
//IList<Product> GetPushlishedProducts(int pageSize = 0, int pageIndex = 0, CatalogSortBy sortBy = CatalogSortBy.DiplayNameAsc);
//IList<Product> GetRelatedProducts(int productId);
//IList<Product> GetDeployedProducts(int pageSize = 0, int pageIndex = 0, CatalogSortBy sortBy = CatalogSortBy.DiplayNameAsc);
//IList<Product> GetRetiredProducts(int pageSize = 0, int pageIndex = 0, CatalogSortBy sortBy = CatalogSortBy.DiplayNameAsc);
//IList<Product> GetDesignProducts(int pageSize = 0, int pageIndex = 0, CatalogSortBy sortBy = CatalogSortBy.DiplayNameAsc);