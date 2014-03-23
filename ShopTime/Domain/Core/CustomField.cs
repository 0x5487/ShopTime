using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.Components.EnterpriseLibrary.Data;

namespace JasonSoft.ShopTime.Domain
{
    public class CustomField
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        [Required]
        [Column("TypeId")]
        public CustomFieldType Type { get; set; }

        public int ParentId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Key { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Value { get; set; }

        public bool IsDeleted { get; set; }

        public virtual AuditInfo AuditInfo { get; set; }

        #region Nagivations




        #endregion
    }

    public enum CustomFieldType
    {
        Collection = 1,
        Product = 2,
    }
}
