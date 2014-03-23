using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Data;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTime.Helper;
using JasonSoft;

namespace JasonSoft.ShopTime.Service
{
    public class CollectionService : ICollectionService
    {
        private IRepository<Collection> _collectionRepo;
        private IRepository<CustomField> _customFieldRepo;
        private IShopTimeToken _token;


        public async Task<IResult<Collection>> GetCollectionAsync(int collectionId)
        {
            IResult<Collection> result = null;

            try
            {
                var collection = _collectionRepo.GetById(collectionId);

                if (collection == null || collection.StoreId != _token.Store.Id)
                {
                    result = new ShopTimeResult<Collection>();
                }

                result = new ShopTimeResult<Collection>(collection);
            }
            catch (Exception ex)
            {
                result = new ShopTimeResult<Collection> {Error = new Error() {CodeNumber = 500, Message = ex.Message}};
            }

            return result;
        }


        public async Task<IResult<Collection>> GetCollectionAsync(string resourceId)
        {
            IResult<Collection> result = null;

            if (resourceId.IsNullOrEmpty())
            {
                return new ShopTimeResult<Collection>(){Error = new Error(){CodeNumber = 500, Message = "resourceId can't be null or empty string"}};
            }

            try
            {
                var map = new UrlToTags(resourceId);

                if (map.IsValid == false)
                {
                    result = new ShopTimeResult<Collection>();
                    return result;
                }

                var collection = _collectionRepo.Table.SingleOrDefault(obj => obj.ResourceId.ToLower() == map.ResourceId && obj.StoreId == _token.Store.Id && obj.IsDeleted == false);
                
                if (collection != null)
                {
                    if (collection.Tags.IsNullOrEmpty() && map.Tags.IsNullOrEmpty() == false)
                    {
                        collection = null;
                    }
                    else if (collection.Tags.IsNullOrEmpty() == false && map.Tags.IsNullOrEmpty() == false)
                    {
                        foreach (var tag in map.Tags)
                        {
                            if (collection.Tags.Contains(tag) == false)
                            {
                                collection = null;
                                break;
                            }
                        }
                    }
                }

                result = new ShopTimeResult<Collection>(collection);
            }
            catch (Exception ex)
            {
                result = new ShopTimeResult<Collection> { Error = new Error() { CodeNumber = 500, Message = ex.Message } };
            }

            return result;
        }

        public async Task<IResult<int>> CreateCollectionAsync(Collection target)
        {
            IResult<int> result = null;

            if (target == null)
            {
                result = new ShopTimeResult<int>
                {
                    Error = new Error() {CodeNumber = 500, Message = "collection can't be null."}
                };
                return result;
            }

            try
            {
                //resourceId can't be the same
                Collection oldCollection = null;
                await GetCollectionAsync(target.ResourceId).Complete((collection, err) =>
                {
                    if (err != null)
                    {
                        result = new ShopTimeResult<int>
                        {
                            Error = err
                        };
                        return;
                    }
                    oldCollection = collection;
                });


                if (oldCollection != null)
                {
                    result = new ShopTimeResult<int>
                    {
                        Error = new Error() { CodeNumber = 500, Message = "resourceId is already existing." }
                    };
                    return result;
                }

                //audit
                var auditInfo = new AuditInfo(_token);

                if (target.ResourceId.IsNullOrWhiteSpace())
                {
                    target.ResourceId = target.ResourceId.Trim();
                }

                target.StoreId = _token.Store.Id;
                target.AuditInfo = auditInfo;


                //insert
                await _collectionRepo.InsertAsync(target).Complete(err =>
                {
                    if (err != null)
                    {
                        result = new ShopTimeResult<int> { Error = err };
                        return;
                    }

                    result = new ShopTimeResult<int>(target.Id);
                });
            }
            catch (Exception ex)
            {
                result = new ShopTimeResult<int>
                {
                    Error = new Error() { CodeNumber = 500, Message = ex.Message }
                };
            }

            return result;
        }


        public async Task<IResult> UpdateCollectionAsync(Collection collection)
        {
            IResult result = null;

            if (collection == null)
            {
                result = new ShopTimeResult()
                {
                    Error = new Error() {CodeNumber = 500, Message = "collection can't be null."}
                };
                return result;
            }

            var updateResult = await _collectionRepo.UpdateAsync(collection);

            if (updateResult.Error != null)
            {
                result = new ShopTimeResult<int> { Error = updateResult.Error };
                return result;
            }

            result = new ShopTimeResult();
            return result;
        }

        public async Task<IResult> DeleteCollectionAsync(Collection collection)
        {
            IResult result = null;

            if (collection == null)
            {
                result = new ShopTimeResult()
                {
                    Error = new Error() { CodeNumber = 500, Message = "collection can't be null." }
                };
                return result;
            }

            //get all custom fields and set to be deleted.
            var getCustomFieldsTask = GetCustomFieldsAsync(collection.Id, true);
            
            collection.IsDeleted = true;
            var updateCollectionTask = _collectionRepo.UpdateAsync(collection);
  
            Task.WaitAll(getCustomFieldsTask);

            if (getCustomFieldsTask.Result.Error != null)
            {
                result = new ShopTimeResult()
                {
                    Error = getCustomFieldsTask.Result.Error
                };
                return result;
            }

            Task<IResult> deleteCustomFieldsTask = null;
            if (getCustomFieldsTask.Result.ResultValue.IsNullOrEmpty() == false)
            {
                deleteCustomFieldsTask = DeleteCustomFieldsAsync(getCustomFieldsTask.Result.ResultValue);
                Task.WaitAll(updateCollectionTask, deleteCustomFieldsTask);

                if (deleteCustomFieldsTask.Result.Error != null)
                {
                    result = new ShopTimeResult()
                    {
                        Error = deleteCustomFieldsTask.Result.Error
                    };
                    return result;
                }
            }
            else
            {
                Task.WaitAll(updateCollectionTask);
            }
            
            if (updateCollectionTask.Result.Error != null)
            {
                result = new ShopTimeResult()
                {
                    Error = updateCollectionTask.Result.Error
                };
                return result;
            }

            result = new ShopTimeResult();
            return result;
        }

        public async Task<IResult> DeleteCollectionsAsync(IList<int> collectionIds)
        {
            throw new NotImplementedException();
        }





        public async Task<IResult<IList<Collection>>> GetCollectionsAsync(int? limit = null, int? page = null, CatalogSortBy? sortBy = null, bool isTracking = true)
        {
            IResult<IList<Collection>> result = null;

            var pager = new Pager(limit, page);

            try
            {
                var collectionQry = _collectionRepo.Table.Where(obj => obj.StoreId == _token.Store.Id && obj.IsDeleted == false);
                        

                switch(sortBy)
                {
                    case CatalogSortBy.DiplayNameAsc:
                        collectionQry = collectionQry.OrderBy(obj => obj.DisplayName);
                        break;
                    default:
                        collectionQry = collectionQry.OrderBy(obj => obj.Id);
                        break;
                }

                collectionQry = collectionQry.Skip(pager.Skip).Take(pager.Take);

                IList<Collection> collections = null;
                if (isTracking)
                {
                    collections = collectionQry.ToList();
                }
                else
                {
                    collections = collectionQry.AsNoTracking().ToList();
                }

                result = new ShopTimeResult<IList<Collection>>(collections);
            }
            catch (Exception ex)
            {
                result = new ShopTimeResult<IList<Collection>>
                {
                    Error = new Error() { CodeNumber = 500, Message = ex.Message }
                };
            }

            return result;
        }

        public async Task<IResult<IList<Collection>>> GetCollectionsAsync(int? productId = null, int? limit = null, int? page = null, CatalogSortBy? sortBy = null, bool isTracking = false)
        {
            throw new NotImplementedException();
        }


        public async Task<IResult<int>> GetCollectionsCountAsync()
        {
            IResult<int> result = null;

            try
            {
                var count = _collectionRepo.Table.Count(obj => obj.StoreId == _token.Store.Id && obj.IsDeleted == false);
                result = new ShopTimeResult<int>(count);
            }
            catch (Exception ex)
            {
                result = new ShopTimeResult<int>
                {
                    Error = new Error() { CodeNumber = 500, Message = ex.Message }
                };
            }

            return result;
        }

        public async Task<IResult<int>> GetCollectionsCountAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult<int>> GetCustomFieldsCountAsync(int collectionId)
        {
            IResult<int> result = null;

            try
            {
                var count = _customFieldRepo.Table.Count(obj => obj.StoreId == _token.Store.Id && obj.Type == CustomFieldType.Collection && obj.ParentId == collectionId && obj.IsDeleted == false);
                result = new ShopTimeResult<int>(count);
            }
            catch (Exception ex)
            {
                result = new ShopTimeResult<int>
                {
                    Error = new Error() { CodeNumber = 500, Message = ex.Message }
                };
            }

            return result;
        }


        public async Task<IResult<IList<CustomField>>> GetCustomFieldsAsync(int collectionId, bool isTracking = true)
        {
            IResult<IList<CustomField>> result = null;

            try
            {
                var customFieldsQry = _customFieldRepo.Table.Where(obj => obj.StoreId == _token.Store.Id && obj.Type == CustomFieldType.Collection && obj.ParentId == collectionId && obj.IsDeleted == false);
                
                IList<CustomField> customFields = null;
                if (isTracking)
                {
                    customFields = customFieldsQry.ToList();
                }
                else
                {
                    customFields = customFieldsQry.AsNoTracking().ToList();
                }

                result = new ShopTimeResult<IList<CustomField>>(customFields);
            }
            catch (Exception ex)
            {
                result = new ShopTimeResult<IList<CustomField>>
                {
                    Error = new Error() { CodeNumber = 500, Message = ex.Message }
                };
            }

            return result;
        }

        public async Task<IResult<CustomField>> GetCustomFieldAsync(int collectionId, int customFieldId)
        {
            IResult<CustomField> result = null;

            try
            {
                var customField = _customFieldRepo.Table.SingleOrDefault(obj=> obj.StoreId == _token.Store.Id && obj.Type == CustomFieldType.Collection && obj.ParentId == collectionId && obj.Id == customFieldId && obj.IsDeleted == false);
                result = new ShopTimeResult<CustomField>(customField);
            }
            catch (Exception ex)
            {
                result = new ShopTimeResult<CustomField>
                {
                    Error = new Error() { CodeNumber = 500, Message = ex.Message }
                };
            }

            return result;
        }

        public async Task<IResult<CustomField>> GetCustomFieldAsync(int collectionId, string key)
        {
            IResult<CustomField> result = null;

            try
            {
                var customField = _customFieldRepo.Table.SingleOrDefault(obj => obj.StoreId == _token.Store.Id && obj.Type == CustomFieldType.Collection && obj.ParentId == collectionId && obj.Key.ToLower() == key.Trim().ToLower() && obj.IsDeleted == false);
                result = new ShopTimeResult<CustomField>(customField);
            }
            catch (Exception ex)
            {
                result = new ShopTimeResult<CustomField>
                {
                    Error = new Error() { CodeNumber = 500, Message = ex.Message }
                };
            }

            return result;
        }

        public async Task<IResult<int>> CreateCustomFieldAsync(int collectionId, CustomField customField)
        {
            IResult<int> result = null;

            if (customField == null)
            {
                result = new ShopTimeResult<int>() { Error = new Error()
                {
                    CodeNumber = 500,
                    Message = "customField can't be null."
                }};
            }

            try
            {
                customField.StoreId = _token.Store.Id;
                customField.Type = CustomFieldType.Collection;
                customField.ParentId = collectionId;

                if (customField.Key.IsNullOrWhiteSpace() == false && customField.Value.IsNullOrWhiteSpace() == false)
                {
                    customField.Key = customField.Key.Trim();
                    customField.Value = customField.Value.Trim();
                }

                customField.AuditInfo = new AuditInfo(_token);
                await _customFieldRepo.InsertAsync(customField).Complete(err =>
                {
                    if (err != null)
                    {
                        result = new ShopTimeResult<int>() {Error = err};
                    }

                    result = new ShopTimeResult<int>(customField.Id);
                });

            }
            catch (Exception ex)
            {
                result = new ShopTimeResult<int>()
                {
                    Error = new Error() { CodeNumber = 500, Message = ex.Message }
                };
                
            }

            return result;
        }

        public async Task<IResult> UpdateCustomFieldAsync(CustomField customField)
        {
            IResult result = null;

            if (customField == null)
            {
                result = new ShopTimeResult()
                {
                    Error = new Error()
                    {
                        CodeNumber = 500,
                        Message = "customField can't be null."
                    }
                };
                return result;
            }

            if (customField.StoreId != _token.Store.Id)
            {
                result = new ShopTimeResult()
                {
                    Error = new Error()
                    {
                        CodeNumber = 500,
                        Message = "invalid operation."
                    }
                };
                return result;
            }


            try
            {
                customField.AuditInfo = new AuditInfo(_token);
                var updateResult = await _customFieldRepo.UpdateAsync(customField);

                if (updateResult.Error != null)
                {
                    result = new ShopTimeResult() {Error = updateResult.Error};
                    return result;
                }

                result = new ShopTimeResult();
            }
            catch (Exception ex)
            {
                result = new ShopTimeResult()
                {
                    Error = new Error() { CodeNumber = 500, Message = ex.Message }
                };
            }

            return result;
        }

        public Task<IResult> UpdateCustomFieldsAsync(IList<CustomField> customField)
        {
            throw new NotImplementedException();
        }


        public async Task<IResult> DeleteCustomFieldAsync(int collectionId, int customFieldId)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> DeleteCustomFieldsAsync(IList<CustomField> customFields)
        {
            IResult result = null;

            if (customFields.IsNullOrEmpty())
            {
                result = new ShopTimeResult()
                {
                    Error = new Error() { Message = "customFields can't be null or empty."}
                };
            }

            try
            {
                foreach (var customField in customFields)
                {
                    customField.IsDeleted = true;
                }

                await _customFieldRepo.UpdateAsync(customFields)
                    .Error(err =>
                    {
                        result = new ShopTimeResult() { Error = err};
                    })
                    .Success(() =>
                    {
                        result = new ShopTimeResult();
                    });

            }
            catch (Exception ex)
            {
                result = new ShopTimeResult()
                {
                    Error = new Error() { CodeNumber = 500, Message = ex.Message }
                };
            }

            return result;
        }

        public  CollectionService(IShopTimeToken token, IRepository<Collection> collectionRepo, IRepository<CustomField> customFieldRepo)
        {
            _collectionRepo = collectionRepo;
            _customFieldRepo = customFieldRepo;
            _token = token;
        }
    }
}
