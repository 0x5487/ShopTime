using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Data
{
    public interface ICollectionDAO
    {
        IResult<int> CreateCollection(Collection collection);

        IResult<Collection> GetCollection(int collectionId);

        IResult<IList<Collection>> GetCollections(int pageSize = ShopTimeSetting.PageSize, int pageIndex = 0);

        IResult UpdateCollection(Collection collection);

        IResult DeleteCollection(int collectionId);

    }
}
