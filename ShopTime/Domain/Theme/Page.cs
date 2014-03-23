using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class Page
    {
        public int PageId { get; set; }

        public byte TypeId { get; set; }

        public string PageTitle { get; set; }

        public string Content { get; set; }

        public int TemplateId { get; set; }


    }
}
