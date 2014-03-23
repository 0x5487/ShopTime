using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTimeMVC.Models
{
    public interface IPaymentMethod
    {
        string Name { get; set; }
    }
}
