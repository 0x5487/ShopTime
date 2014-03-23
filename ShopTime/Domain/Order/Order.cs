using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class Order
    {
        public Guid OrderGuid { get; set; }        

        public long OrderId { get; set; }

        public int? ShopperId { get; set; }

        public bool IsTestOrder { get; set; }

        public IList<LineItem> LineItems { get; set; }

        public ContactInfo BillingAddressInfo { get; set; }

        public ContactInfo ShippingAddressInfo { get; set; }

        public ShippingOption ShippingOption { get; set; }

        public IList<Shipment> Shipments { get; set; }

        public ShippingStatus ShippingStatus { get; set; }

        public decimal OrderShippingFee { get; set; }

        public decimal OrderShippingFeeWithTax { get; set; }

        public decimal OrderSubTotal { get; set; }

        public decimal OrderSubTotalWithTax { get; set; }

        public decimal PaymentMethodAdditionalFee { get; set; }

        public decimal PaymentMethodAdditionalFeeWithTax { get; set; }

        public decimal OrderDiscount { get; set; }

        public decimal OrderTotalTax { get; set; }

        public decimal OrderTotalPrice { get; set; }

        public decimal OrderTotalPriceWithTax { get; set; }      

        public OrderStatus OrderStatus { get; set; }

        public PaymentMethod PaymentMethod { get; set; }  

        public decimal CurrencyRate { get; set; }

        public string CurrencyCode { get; set; }

        public string Locale { get; set; }

        public string Language { get; set; }

        public string VatNumber { get; set; }

        public decimal TotalAuthorized { get; set; }

        public decimal TotalRefunded { get; set; }

        public decimal TotalSettled { get; set; }

        public decimal TotalCancelled { get; set; }

        public int ShopperIp { get; set; }        

        public TaxDisplayType TaxDisplayType { get; set; }

        public DateTime? PaidDateUtc { get; set; }

        public string ReferringSite { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public string LastModifierUserId { get; set; }

        public string LastModifierUserName { get; set; }

        public DateTime LastModifiedDateUtc { get; set; }
    }
    
}
