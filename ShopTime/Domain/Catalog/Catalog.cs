using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class Catalog
    {
        public Catalog() 
        {
            TypeId = 1;
        }

        public int CatalogId { get; set; }

        public byte TypeId { get; set; }

        public string CatalogName { get; set; }

        public string DisplayName { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public int CreatedUserId { get; set; }

        public string CreatedUserName { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public DateTime LastModifiedDateUtc { get; set; }


    }
}
