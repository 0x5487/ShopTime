using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using JasonSoft.ShopTime.Domain;
using JasonSoft.ShopTime.Data;

namespace JasonSoft.ShopTime.Service
{
    public interface IShoppingCartService
    {

        IShopTimeToken ShopTimeToken { get; set; }
 
        
        //ShoppingCartResult AddProductToCart(int productId, int quantity = 1);

        LineItem GetShoppingCartItem(Guid lineItemGuid);

        IList<LineItem> GetShoppingCartItems();

        //ShoppingCartResult UpdateShoppingCartItem(Guid shoppingCartItemId, int newQuantity);

        //ShoppingCartResult RemoveShoppingCartItem(Guid shoppingCartItemId);

        //ShoppingCartResult VerifyShoppingCartItem(Guid shoppingCartItemId);

        //ShoppingCartResult VerifyShoppingCart();

        OrderTotalPriceInfo GetOrderTotalPriceInfo();

        void EmptyShopperShoppingCart();

    }
}
