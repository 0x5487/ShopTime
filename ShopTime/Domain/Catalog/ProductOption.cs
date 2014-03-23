using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class ProductOption
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public int ProductId { get; set; }

        public Option Option { get; set; }

        public bool IsRequired { get; set; }

        public short Position { get; set; }

        public virtual AuditInfo AuditInfo { get; set; }

        #region Nagivations

        public virtual Product Product { get; set; }

        #endregion
    }
}
