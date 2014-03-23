using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class Shopper
    {
        public Guid ShopperGuid { get; set; }

        public int ShopperId { get; set; }

        public string shopperEmail { get; set; }

        public int StoreId { get; set; }

        public bool IsAnonymous { get; set; }

        public int ShopperIp { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public DateTime LastLoginTime { get; set; }
    }
}
