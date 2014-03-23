using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.EStore.Domain
{
    public class Coupon
    {
        public int CouponId { get; set; }

        public string Code { get; set; }


        public int CreatedUserId { get; set; }

        public string CreatedUserName { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public string LastModifierUserId { get; set; }

        public string LastModifierUserName { get; set; }

        public DateTime LastModifiedDateUtc { get; set; }

    }
}
