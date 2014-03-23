using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JasonSoft.ShopTimeMVC.Models
{
    public class OnePageCheckoutViewModel : IValidatableObject
    {
        [Required]
        public string Action { get; set; }


        [RequiredIf("Action", "login")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [RequiredIf("Action", "login")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }


        [RequiredIf("Action", "continue",ErrorMessage="Your first name can't be empty")]
        public string BillingFirstName { get; set; }

        [RequiredIf("Action", "continue")]
        public string BillingLastName { get; set; }

        [RequiredIf("Action", "continue")]
        public string BillingAddress1 { get; set; }


        public string BillingAddress2 { get; set; }


        public bool IsSameAsBilling { get; set; }


        public string ShippingFirstName { get; set; }


        public string ShippingLastName { get; set; }


        public string ShippingAddress1 { get; set; }


        public string ShippingAddress2 { get; set; }

        [RequiredIf("Action", "continue")]
        public string SelectedPaymentNameId { get; set; }


        public string CreditCardNumber { get; set; }


        public DateTime ExpirationDate { get; set; }

        
        public int SecurityCode { get; set; }
        
        
        public IList<IPaymentMethod> PaymentMethods { get; set; }

        public OnePageCheckoutViewModel()
        {
            this.PaymentMethods = new List<IPaymentMethod>();
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Action == "continue" && SelectedPaymentNameId == "CreditCard" && CreditCardNumber.IsNullOrEmpty())
                yield return new ValidationResult("CreditCardNumber can't be empty", new[] { "CreditCardNumber" });


        }
    }
}