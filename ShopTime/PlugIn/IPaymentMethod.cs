using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;


namespace JasonSoft.ShopTime.Plugin
{
    public interface IPaymentMethod
    {
        PaymentResult ProcessPayment(PaymentRequest paymentRequest);

        void PostProcessPayment(PostProcessPaymentRequest postProcessPaymentRequest);

        RefundPaymentResult RefundPayment(RefundPaymentRequest refundPaymentRequest);

        VoidPaymentResult VoidPayment(VoidPaymentRequest voidPaymentRequest);

        decimal GetAdditionalHandlingFee(IList<LineItem> cart);

    }
}
