using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Service
{
    public interface IStoreService
    {

        void CreateStore(Store store);
        IList<Store> GetStores(int companyId);
        Store GetStore(int storeId);
        StoreServiceResult UpdateStore(Store store);

        IList<Country> GetBillingCountries();
        IList<Country> GetShippingCountries();

        void AddLocale(int storeId, string locale);
        IList<string> GetSupportLocales(int storeId);
        void DeleteLocale(int storeId, string locale);


        void AddCurrency(int storeId, string locale, string currency);
        IList<string> GetSupportCurrency(int storeId, string locale);
        void DeleteCurrency(int storeId, string locale, string currency);


    }
}
