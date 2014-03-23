using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Service
{
    public interface IOrderService
    {
        IShopTimeToken ShopTimeToken { get; set; }
        ITaxService TaxService { get; set; }


        //OrderServiceResult PlaceOrder();

        Order GetOrder(long orderId);

        IList<Order> GetOrders(string emailAddress);

        void CancelOrder(long orderId, bool notifyShopper);

        void MarkOrderAsPaid(long orderId);

        void Refund(long orderId);

        void RefundPartially(long orderId, decimal amountToRefund);

        void VoidOrder(long orderId);


        IList<TransactionDetail> GetTransactionDetails(long orderId);


    }
}
