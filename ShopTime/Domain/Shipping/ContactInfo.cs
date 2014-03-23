using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class ContactInfo
    {
        public int AddressInfoId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public string Division { get; set; }

        public int CountryId { get; set; }

        public string City { get; set; }

        public int StateProvinceId { get; set; }

        public int DistrictId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }    
        
        public string ZipPostalCode { get; set; }

        public string Email { get; set; }

        public string HomePhoneNumber { get; set; }

        public string WorkPhoneNumber { get; set; }        

        public string FaxNumber { get; set; }

        public string Cellular { get; set; }

        public DateTime CreatedDateUtc { get; set; }
    }
}
