using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Data
{
    public class MetaDataEntity
    {

        public int Id { get; set; }

        public int StoreId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Namespace { get; set; }

        public AuditInfo AuditInfo { get; set; }
    }
}
