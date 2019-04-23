namespace BillsPaymentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"\b[A-Za-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}\b")]
        public string Email { get; set; }

        [Required]
        [MinLength(6), MaxLength(20)]
        public string Password { get; set; }

        public ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
    }
}
