using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class Template
    {
        public int TemplateId { get; set; }

        public byte TypeId { get; set; }

        public string TemplateName { get; set; }

        public bool IsDeletable { get; set; }

        public string Content { get; set; }
    }
}
