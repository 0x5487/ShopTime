using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class TransactionDetail
    {
        public int TransactionDetailId {get; set;}

        public PaymentType PaymentType { get; set; }

        public decimal RequestAmount { get; set; }

        public decimal ResponseAmount { get; set; }

        public CardType CardType { get; set; }

        public int CardLastFourDigital { get; set; }

        public DateTime CardExpiredDate { get; set; }

        public DateTime CreatedDateUtc { get; set; }


    }
}
