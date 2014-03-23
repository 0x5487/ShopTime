using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public enum PaymentType
    {
        Paid = 10,
        Cancelled = 20,
        Pending = 30,
        Authorized = 40,
        PartiallyRefunded = 50,
        Refunded = 60,
        Voided = 70,
        RequestFunds,

    }
}
