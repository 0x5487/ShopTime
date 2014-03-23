using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Data;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Service
{
    public class ProductService : IProductService
    {

        private readonly IDBConetxt _repository;
        private ICollectionService _collectionService;
        private IShopTimeToken _token;

        public ProductServiceResult CreateProduct(Product product)
        {
            return this.CreateProduct(product, null);
        }

        public ProductServiceResult CreateProduct(Product product, int[] collectionIds)
        {
            //var result = new ProductServiceResult();

            //if (product == null)
            //{
            //    result.ExceptionInfo.Add(new ExceptionInfo() { Message = "product can't be null." });
            //    return result;
            //}

            //if (product.ProductId > 0)
            //{
            //    result.ExceptionInfo.Add(new ExceptionInfo() { Message = "product id can't be greater than 0." });
            //    return result;
            //}

            //try
            //{
            //    foreach (var collectionId in collectionIds)
            //    {
            //        var collection = _collectionService.GetCollection(collectionId);
            //        product.Collections.Add(collection);
            //    }

            //    product.AuditInfo = new AuditInfo(_token);

            //    foreach (var image in product.Images)
            //    {
            //        image.AuditInfo = new AuditInfo(_token);
            //    }
            //    _repository.Products.Add(product);
            //    _repository.SaveChanges();
            //    result.Status = ResultStatus.Success;
            //}
            //catch (Exception ex)
            //{
            //    result.ExceptionInfo.Add(new ExceptionInfo() { Message = ex.Message });
            //}

            //return result;
            throw new NotImplementedException();
        }

        public ProductServiceResult UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(string resourceId)
        {
            throw new NotImplementedException();
        }

        public ProductServiceResult RemoveProducts(IList<int> productIds)
        {
            throw new NotImplementedException();
        }

        public int GetCountOfProducts(int collectionId, string filterByTag = null)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetProductsByCollection(int collectionId, string filterByTag = null, int pageSize = ShopTimeSetting.PageSize, int pageIndex = 0,
            CatalogSortBy sortBy = CatalogSortBy.DiplayNameAsc)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetProducts(int pageSize = ShopTimeSetting.PageSize, int pageIndex = 0, CatalogSortBy sortBy = CatalogSortBy.DiplayNameAsc)
        {
            throw new NotImplementedException();
        }

        public IList<Image> GetProductImages(int productId)
        {
            throw new NotImplementedException();
        }


        public ProductService(IShopTimeToken token, ICollectionService collectionService, IDBConetxt repository)
        {
            _repository = repository;
            _token = token;
            _collectionService = collectionService;
        }

    }
}
