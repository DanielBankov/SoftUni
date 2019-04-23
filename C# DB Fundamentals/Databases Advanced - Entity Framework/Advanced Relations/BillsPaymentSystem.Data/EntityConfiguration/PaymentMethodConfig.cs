using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPaymentSystem.Data.EntityConfiguration
{
    public class PaymentMethodConfig : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasOne(b => b.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(b => b.UserId);

            builder.HasOne(b => b.BankAccount)
                .WithOne(b => b.PaymentMethod);

            builder.HasOne(b => b.CreditCard)
                .WithOne(c => c.PaymentMethod);
        }
    }
}