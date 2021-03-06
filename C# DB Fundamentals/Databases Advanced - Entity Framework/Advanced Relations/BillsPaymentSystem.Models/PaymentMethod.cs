﻿namespace BillsPaymentSystem.Models
{
    using BillsPaymentSystem.Models.Attribute;
    using Enums;

    public class PaymentMethod
    {
        public int Id { get; set; }

        public PaymentMethodType Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [Xor(nameof(CreditCardId))]
        public int? BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
