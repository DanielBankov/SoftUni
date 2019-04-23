using BillsPaymentSystem.Models.Attribute;
using System;
using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.Models
{
    public class CreditCard
    {
        [Key]
        public int CreditCardId { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Limit { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal MoneyOwed { get; set; }

        //[NotMapped]
        public decimal LimitLife => Limit - MoneyOwed;

        [ExpirationDateAttribute]
        public DateTime ExpirationDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
