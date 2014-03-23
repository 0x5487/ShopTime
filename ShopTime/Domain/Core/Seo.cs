using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft.ShopTime.Domain
{
    public class Seo
    {

        public string PageTitle { get; set; }

        public string PageDescription { get; set; }

        [NotMapped]
        public string PageUrl { get; set; }

    }
}
