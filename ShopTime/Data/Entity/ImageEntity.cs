using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Data.Table
{
    public class ImageEntity
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public byte? Position { get; set; }

        public IList<CustomField> MetaData { get; set; }

        public AuditInfo AuditInfo { get; set; }

    }
}
