using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Data;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Service
{
    public interface ICollectionService
    {

        Task<IResult<int>> CreateCollectionAsync(Collection target);

        //CollectionServiceResult CreateCollection(Collection collection, int[] productIds);

        Task<IResult> UpdateCollectionAsync(Collection collection);

        Task<IResult> DeleteCollectionAsync(Collection collection);

        Task<IResult> DeleteCollectionsAsync(IList<int> collectionIds);

        Task<IResult<Collection>> GetCollectionAsync(int collectionId);

        Task<IResult<Collection>> GetCollectionAsync(string resourceId);

        Task<IResult<IList<Collection>>> GetCollectionsAsync(int? limit = null, int? page = null, CatalogSortBy? sortBy = null, bool isTracking = false);

        Task<IResult<IList<Collection>>> GetCollectionsAsync(int? productId = null, int? limit = null, int? page = null, CatalogSortBy? sortBy = null, bool isTracking = true);

        Task<IResult<int>> GetCollectionsCountAsync();

        Task<IResult<int>> GetCollectionsCountAsync(int productId);

        //CollectionServiceResult AddProductToCollection(int collectionId, int productId);

        //CollectionServiceResult AddProductsToCollection(int collectionId, int[] productIds);

        #region CustomFields

        Task<IResult<int>> GetCustomFieldsCountAsync(int collectionId);

        Task<IResult<IList<CustomField>>> GetCustomFieldsAsync(int collectionId, bool isTracking = true);

        Task<IResult<CustomField>> GetCustomFieldAsync(int collectionId, int customFieldId);

        Task<IResult<CustomField>> GetCustomFieldAsync(int collectionId, string key);

        Task<IResult<int>> CreateCustomFieldAsync(int collectionId, CustomField customField);

        Task<IResult> UpdateCustomFieldAsync(CustomField customField);

        Task<IResult> UpdateCustomFieldsAsync(IList<CustomField> customFields);

        Task<IResult> DeleteCustomFieldAsync(int collectionId, int customFieldId);

        Task<IResult> DeleteCustomFieldsAsync(IList<CustomField> customFields);

        #endregion
    }
}
