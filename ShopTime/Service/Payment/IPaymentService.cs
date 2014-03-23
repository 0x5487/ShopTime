using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Service
{
    interface IPaymentService
    {

        IEnumerable<PaymentMethod> GetPaymentMethods();

        IEnumerable<PaymentMethod> GetActivePaymentMethods();

    }
}
