using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Service
{
    interface ICustomerService
    {
        void CreateCustomer(Shopper shopper);

        void Login(string username, string password);

        void Logout();

        void ForgetPassword(string email);


    }
}
