using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Service
{
    public interface ICatalogService
    {
        ////catalog
        //Catalog GetCatalog(int catalogId);
        //IList<Catalog> GetCatalogs();
        //CatalogResult CreateCatalog(Catalog catalog);
        //CatalogResult CreateCategory(Category category);
        //Category GetCategory(int categoryId);
        //CatalogResult DeleteCategory(int categoryId);


        ////categories
        //Category GetCategory(string resourceId);
        //Category GetCategoryWithProducts(string resourceId);
        //IList<Category> GetCategories(int productId);        
        //IList<Category> GetCategories(int parentCategoryId, CatalogSortBy sortBy, int pageSize = 0, int pageIndex = 0);


        ////products
        //CatalogResult CreateProduct(Product product);
        //CatalogResult UpdateProduct(Product product);
        //Product GetProduct(int productId);
        //Product GetProduct(Guid productGuid);
        //Product GetProduct(string resourceId);
        //IList<Product> GetProducts(int categoryId, int pageSize = 0, int pageIndex = 0, CatalogSortBy sortBy = CatalogSortBy.DiplayNameAsc);
        //int GetAllProductsCount(int categoryId);

  
    }
}
