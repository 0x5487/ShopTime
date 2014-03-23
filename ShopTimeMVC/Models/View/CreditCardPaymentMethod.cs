using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using JasonSoft;


namespace JasonSoft.ShopTimeMVC.Models
{
    public class CreditCardPaymentMethod : IValidatableObject, IPaymentMethod
    {
        public CreditCardPaymentMethod() 
        {
            this.Name = "CreditCard";
        }

        public string Name { get; set; }


        public string CreditCardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int SecurityCode { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CreditCardNumber.IsNullOrEmpty())
                yield return new ValidationResult("CreditCard can't be emptyr", new[] { "CreditCardNumber" });


        }

    }
}