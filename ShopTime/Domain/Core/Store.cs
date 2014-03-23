using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace JasonSoft.ShopTime.Domain
{
    //cache 
    public class Store
    {
        public Store()
        {
            StoreStatus = StoreStatus.Preparing;
            MaximumCartQuantity = 99;
        }

        public int Id { get; set; }

        public string StoreName { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public string DefaultLocale { get; set; }

        [NotMapped]
        public ContactInfo StoreAddressInfo { get; set; }

        public string DomainName { get; set; }        

        public string AccountEmail { get; set; }

        public string CustomerEmail { get; set; }

        public StoreStatus StoreStatus { get; set; }

        public string Theme { get; set; }

        [NotMapped]
        public IList<CultureInfo> SupportLocales { get; set; }

        public string TimeZone { get; set; }

        #region Store Setting

        public CheckoutType DefaultCheckoutType { get; set; }

        public string ContinueShoppingUrl { get; set; }

        public int DefaultCatalogId { get; set; }

        public string CurrencyFormat { get; set; }


        #endregion       
        
        #region ShoppingCart Setting

        public byte MaximumCartQuantity { get; set; }


        #endregion

        [NotMapped]
        public virtual AuditInfo AuditInfo { get; set; }

        #region Relationship
        public int OwnerUserId { get; set; }


        #endregion

    }
}
