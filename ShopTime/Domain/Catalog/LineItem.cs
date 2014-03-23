using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class LineItem
    {
        public Guid LineItemGuid { get; set; }

        public int LineItemId { get; set; }

        public Product Product { get; set; }

        public short Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal UnitPriceWithTax { get; set; }

        public decimal ListPrice { get; set; }

        public decimal ListPriceWithTax { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal TotalPriceWithTax { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal DiscountAmountWithTax { get; set; }

        public decimal TotalWeight { get; set; }

        public bool IsQuantityUpdatable { get; set; }

        public bool IsDeleteable { get; set; }

        public ShippingStatus ShippingStatus { get; set; }

        public ShippingProvider ShippingProdivder { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public DateTime LastModifiedDateUtc { get; set; }



    }
}
