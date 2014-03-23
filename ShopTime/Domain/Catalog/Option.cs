using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class Option
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public virtual AuditInfo AuditInfo { get; set; }


        #region Nagivations

        public virtual ICollection<OptionValue> OptionValues { get; set; }

        #endregion

    }
}
