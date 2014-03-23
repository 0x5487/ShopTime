using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.PlugIn
{
    public interface IWarehouseProvider
    {       

        IEnumerable<Product> GetLowStockProducts(int belowNumber);



        void IncreaseInventory(Product product, int quantity);

        void DecreaseInventory(Product product, int quantity);
    }
}
