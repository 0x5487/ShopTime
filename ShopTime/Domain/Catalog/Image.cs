using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Domain
{
    public class Image
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        [NotMapped]
        public string Url { get; set; }

        public string FileName { get; set; }

        [NotMapped]
        public string Attachment { get; set; }

        public int Position { get; set; }

        public virtual AuditInfo AuditInfo { get; set; }



        #region Nagivations


        public virtual ICollection<CustomField> CustomFields { get; set; }

        #endregion
    }
}
