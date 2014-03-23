using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class Country
    {
        public int CountryId { get; set; }

        public string DisplayName { get; set; }        

        public bool AllowsBilling { get; set; }

        public bool AllowsShipping { get; set; }

        public string TwoLetterIsoCode { get; set; }

        public string ThreeLetterIsoCode { get; set; }

        public bool IsTaxInclusive { get; set; }

        public short DisplayOrder { get; set; }   
    }
}
