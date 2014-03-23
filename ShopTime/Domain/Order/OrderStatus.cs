using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public enum OrderStatus
    {
        Open,
        Processing,
        Cancelled,
        PostPone,
        Pending,
        Complete,
        Close,
        Error,
    }
}
