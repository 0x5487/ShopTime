using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JasonSoft.ShopTime.Domain
{
    public class Collection
    {
        public int Id { get; set; }

        [Index("StoreId_DisplayName", IsUnique = true)]
        [Index("StoreId_ResourceId", IsUnique = true)]
        public int StoreId { get; set; }

        public int ImageId { get; set; }

        [Index("StoreId_ResourceId", IsUnique = true)]
        [Required(AllowEmptyStrings = false)]
        public string ResourceId { get; set; }

        [Index("StoreId_DisplayName", IsUnique = true)]
        [Required(AllowEmptyStrings = false)]
        public string DisplayName { get; set; }

        public bool IsVisible { get; set; }

        public string Description { get; set; }

        public Seo SeoSetting { get; set; }

        private IList<String> _tags;

        [Column("Tags")]
        public string TagsInDB
        {
            get { return String.Join(",", _tags); }
            set { _tags = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList(); }
        }

        [NotMapped]
        public IList<string> Tags
        {
            get
            {
                return _tags;
            }
            set
            {
                _tags = value;
            }
        }

        public bool IsDeleted { get; set; }

        public virtual AuditInfo AuditInfo { get; set; }


        #region Nagivations

        public virtual ICollection<Product> Products { get; set; }

        #endregion


        

        public Collection()
        {
            _tags = new List<string>();
            SeoSetting = new Seo();
        }


        public class CollectionConfiguration : EntityTypeConfiguration<Collection>
        {
            public CollectionConfiguration()
            {
                Property(p => p.TagsInDB);
            }
        }

    }
}
