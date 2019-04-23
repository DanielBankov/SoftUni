using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BillsPaymentSystem.Models.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExpirationDateAttribute : ValidationAttribute  
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currendDateTime = DateTime.Now;
            var expirationDateTime = (DateTime)value;

            if(currendDateTime > expirationDateTime)
            {
                return new ValidationResult("Card is Expired!");
            }

            return ValidationResult.Success;
        }
    }
}
