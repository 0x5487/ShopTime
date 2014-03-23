using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.EStore.Domain
{
    public class Offer
    {
        public int OfferId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ExternalOfferId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DiscountLevel DiscountLevel { get; set; }

        public DiscountLimitation DiscountLimitation { get; set; }

        public int Times { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public DateTime LastModifiedDateUtc { get; set; }
        
    }



    public enum DiscountLevel
    {
        Product =1,
        Order =2,
        Category = 3,
    }

    public enum DiscountLimitation 
    {
        Unlimited = 1,
        N_Times_Only = 2,
        N_Times_Per_Customer = 3
    }

    public enum ProductEligibility 
    {
        All_Product = 1,
        All_Products_Except_Excluded_Products =2,
        All_Categories_Except_Excluded_Categories = 3,
        Specific_Products = 4,
        Specific_Categories = 5,
    }

}
