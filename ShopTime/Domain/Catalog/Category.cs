using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class Category
    {
        public Category() 
        {
            TypeId = 2;
        }

        public int CategoryId { get; set; }

        public byte TypeId { get; set; }
        
        public string DisplayName { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public bool DisplayCategory { get; set; }

        public Seo SeoSetting { get; set; }

        public int CreatedUserId { get; set; }

        public string CreatedUserName { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public string LastModifierUserId { get; set; }

        public string LastModifierUserName { get; set; }

        public DateTime LastModifiedDateUtc { get; set; }

    }
}
