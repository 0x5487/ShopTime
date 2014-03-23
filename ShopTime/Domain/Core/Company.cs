using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string DatabaseName { get; set; }

        public string DatabaseVersion { get; set; }

        public string CompanyName { get; set; }

        public string DisplayName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public int CreatedUserId { get; set; }

        public string CreatedUserName { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public string LastModifierUserId { get; set; }

        public string LastModifierUserName { get; set; }

        public DateTime LastModifiedDateUtc { get; set; }
        
    }
}
