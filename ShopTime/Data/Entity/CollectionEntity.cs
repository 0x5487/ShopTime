using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Data.Table;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Data
{
    public class CollectionEntity
    {
        [Key]
        public int Id { get; set; }
        
        public int StoreId { get; set; }

        [Required]
        public string ResourceId { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public ImageEntity Image { get; set; }

        public bool IsVisible { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }

        public virtual ICollection<MetaDataEntity> MetaData { get; set; }

        public Seo SeoSetting { get; set; }

        public AuditInfo AuditInfo { get; set; }

    }
}
