using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }        

        public string DisplayName { get; set; }

        public string SystemName { get; set; }

        public SettlementType SettlementType { get; set; }

        public IList<string> SupportCurrencies { get; set; }

        public bool IsRefundable { get; set; }

        public bool IsPartitalRefunable { get; set; }

        public bool IsVoidable { get; set; }

        public bool IsActive { get; set; }




    }
}
