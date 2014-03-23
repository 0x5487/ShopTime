using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class ThemeNode
    {
        public int ThemeNodeId { get; set; }

        public int ParentNodeId { get; set; }

        public short TypeId { get; set; }

        public int TargetId { get; set; }

        public bool HasChildNode { get; set; }

        public string DisplayName { get; set; }

        public int CreatedUserId { get; set; }

        public string CreatedUserName { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public DateTime LastModifiedDateUtc { get; set; }
    }
}
