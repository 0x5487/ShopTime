using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JasonSoft.ShopTimeMVC.Models
{
    public class PlaceOrderModel : IValidatableObject
    {

        public bool IsShippingRequired { get; set; }
        

        public int SelectedShippingOptionId { get; set; }

        


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsShippingRequired && SelectedShippingOptionId == 0)
            {
                yield return new ValidationResult("Please select one shipping options.", new[] { "SelectedShippingOptionId" });
            }              
        }

    }
}