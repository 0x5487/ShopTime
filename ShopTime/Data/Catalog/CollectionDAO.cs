using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTime.Helper;

namespace JasonSoft.ShopTime.Data
{
    //public partial class ShopTimeDbContext 
    //{

        //public IResult<int> CreateCollection(Collection collection)
        //{
        //    IResult<int> result = null;

        //    if (collection == null)
        //    {
        //        result = new ShopTimeResult<int>
        //        {
        //            Error = new Error() {CodeNumber = 500, Message = "collection can't be null or empty."}
        //        };
        //        return result;
        //    }

        //    try {
        //        var collectionEntity = Mapper.Map<CollectionEntity>(collection);
        //        var auditInfo = new AuditInfo(_token);
        //        collectionEntity.AuditInfo = auditInfo;
                
        //        collectionEntity = CollectionEntities.Add(collectionEntity);

        //        if (!collection.Products.IsNullOrEmpty())
        //        {
        //            foreach (var product in collection.Products)
        //            {
        //                var productEntity = this.ProductEntities.SingleOrDefault(obj => obj.Id == product.Id && obj.StoreId == _token.Store.StoreId);

        //                if (productEntity != null)
        //                {
        //                    collectionEntity.Products.Add(productEntity);
        //                }


        //                //IsProductExisting(product.ProductId)
        //                //    .Success( () =>
        //                //    {
        //                //        this.CollectionProductTable.Add(new CollectionProductRow()
        //                //        {
        //                //            CollectionId = collectionEntity.Id,
        //                //            ProductId = product.ProductId,
        //                //            AuditInfo = auditInfo
        //                //        });
        //                //    });
        //            }
        //        }

        //        if (!collection.CustomFields.IsNullOrEmpty())
        //        {
        //            //foreach (var metaData in collection.MetaData)
        //            //{
        //            //    IsMetaDataExisting(metaData.Id)
        //            //        .Success(() => this.CollectionMetaDataTable.Add(new CollectionMetaDataEntity()
        //            //        {
        //            //            CollectionId = collectionEntity.Id,
        //            //            MetaDataId = metaData.Id,
        //            //            AuditInfo = auditInfo
        //            //        }));
        //            //}
        //        }

        //        CurrentContext.SaveChanges();
        //        result = new ShopTimeResult<int>(collectionEntity.Id);
        //    }
        //    catch(Exception ex)
        //    {
        //        result = new ShopTimeResult<int> {Error = new Error() {CodeNumber = 500, Message = ex.Message}};
        //    }

        //    return result;
        //}

        //public IResult<Collection> GetCollection(int collectionId)
        //{
        //    IResult<Collection> result = null;

        //    try
        //    {                
        //        var collectionRow = CollectionEntities.AsNoTracking().SingleOrDefault(obj => obj.Id == collectionId);

        //        var collection = Mapper.Map<Collection>(collectionRow);
        //        result = new ShopTimeResult<Collection>(collection);
        //    }
        //    catch (Exception ex)
        //    {
        //        result = new ShopTimeResult<Collection>();
        //        result.Error = new Error() { CodeNumber = 500, Message = ex.Message };
        //    }

        //    return result;
        //}

        //public IResult<IList<Collection>> GetCollections(int pageSize = ShopTimeSetting.PageSize, int pageIndex = 0)
        //{
        //    throw new NotImplementedException();
        //}

        //public IResult UpdateCollection(Collection collection)
        //{
        //    IResult result = null;

        //    try
        //    {
        //        var oldCollection = CollectionEntities.SingleOrDefault(obj => obj.Id == collection.Id);

        //        if (oldCollection == null) 
        //        {
        //            result.Error = new Error() { CodeNumber = 404, Message = "collection is not found" };
        //        }

        //        CurrentContext.Entry(oldCollection).CurrentValues.SetValues(collection);
        //        CurrentContext.SaveChanges();
        //        result = new ShopTimeResult();
        //    }
        //    catch (Exception ex)
        //    {
        //        result = new ShopTimeResult();
        //        result.Error = new Error() { CodeNumber = 500, Message = ex.Message };
        //    }

        //    return result;
        //}

        //public IResult DeleteCollection( int collectionId)
        //{
        //    IResult result = null;

        //    try
        //    {
        //        var oldCollection = CollectionEntities.SingleOrDefault(obj => obj.Id == collectionId);

        //        if (oldCollection == null)
        //        {
        //            result.Error = new Error() { CodeNumber = 404, Message = "collection is not found" };
        //        }

        //        CollectionEntities.Remove(oldCollection);
        //        CurrentContext.SaveChanges();

        //        result = new ShopTimeResult();
        //    }
        //    catch (Exception ex)
        //    {
        //        result = new ShopTimeResult();
        //        result.Error = new Error() { CodeNumber = 500, Message = ex.Message };
        //    }

        //    return result;
        //}


        //private IResult<bool> IsCollectionExisting(int collectionId)
        //{
        //    IResult<bool> result = null;

        //    try
        //    {
        //        var answer = this.CollectionEntities.Any(obj => obj.Id == collectionId && obj.StoreId == this._token.Store.StoreId);
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
