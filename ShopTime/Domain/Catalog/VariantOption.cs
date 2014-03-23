using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class VariantOption
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public Option Option { get; set; }

        public OptionValue OptionValue { get; set; }

        public virtual AuditInfo AuditInfo { get; set; }

        #region Navigations

        public virtual Variant Variant { get; set; }
        public virtual Store Store { get; set; }

        #endregion
    }
}
