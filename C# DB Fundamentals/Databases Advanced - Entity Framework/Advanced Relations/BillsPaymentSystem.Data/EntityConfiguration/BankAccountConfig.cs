using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPaymentSystem.Data.EntityConfiguration
{
    public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.Property(p => p.BankName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.SwiftCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
