using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Data;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTime.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace JasonSoft.ShopTime.Tests
{
    [TestClass]
    public class CollectionDAOTest
    {
        [TestMethod]
        public void Create_collection()
        {
            //var repository = new ShopTimeRepository();
            //IShopTimeToken token = new ShopTimeToken();

            //var collectionDao = new CollectionDAO(token, repository);
            //var collections = collectionDao.GetCollections();
            //collections.Should().BeNull();

            //var menCollection = new Collection();
            //menCollection.DisplayName = "DisplayName_Men";
            //menCollection.ReousceId = "Men";
            //menCollection.Tags.Add("shirt_tee");
            //menCollection.Tags.Add("long_tee");
            //menCollection.Tags.Add("polo");
            //menCollection.Tags.Add("jeans");
            //menCollection.Tags.Add("underwear");
            //menCollection.Tags.Add("領帶");

            //collectionDao.CreateCollection(menCollection);

            //collections = collectionDao.GetCollections();
            //collections.Count.Should().Be(1);

            //var newMenCollection = collectionDao.GetCollection(menCollection.CollectionId);
            ////newMenCollection.ShouldHave().AllProperties().EqualTo(menCollection);
        }

    }
}
