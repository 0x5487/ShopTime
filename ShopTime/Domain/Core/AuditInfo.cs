using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class AuditInfo
    {
        public int CreatedUserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UpdatedUserId { get; set; }

        public DateTime UpdatedAt { get; set; }

        public AuditInfo()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public AuditInfo(IShopTimeToken token): this()
        {
            CreatedUserId = token.UserProfile.UserId;
            UpdatedUserId = token.UserProfile.UserId;
        }
    }
}
