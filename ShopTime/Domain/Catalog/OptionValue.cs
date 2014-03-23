using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class OptionValue
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public int OptionId { get; set; }

        public string Label { get; set; }

        public string Value { get; set; }

        public short Position { get; set; }

        public virtual AuditInfo AuditInfo { get; set; }


        #region Nagivations

        public virtual Store Store { get; set; }
        public virtual Option Option { get; set; }
        public virtual IList<OptionValue> OptionValues { get; set; }

        #endregion
    }
}
