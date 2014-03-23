using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Data
{
    public class CollectionProductRow
    {
        [Key]
        public int Id { get; set; }


        public int CollectionId { get; set; }


        public int ProductId { get; set; }


        public AuditInfo AuditInfo { get; set; }

    }
}
