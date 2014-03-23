using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    //cache
    public class ShopTimeUserProfile
    {
        public Guid UserGuid { get; set; }

        public int UserId { get; set; }

        public string LoginName { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public int TimeZone { get; set; }

        public int CreatedUserId { get; set; }

        public string CreatedUserName { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public string LastModifierUserId { get; set; }

        public string LastModifierUserName { get; set; }

        public DateTime LastModifiedDateUtc { get; set; }
    }
}
