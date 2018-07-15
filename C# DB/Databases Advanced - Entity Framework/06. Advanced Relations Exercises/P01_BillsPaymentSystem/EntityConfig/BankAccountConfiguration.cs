namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(ba => ba.BankAccountId);

            builder.Property(ba => ba.Balance).IsRequired();

            builder.Property(ba => ba.BankName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(ba => ba.SWIFTCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder.HasOne(cc => cc.PaymentMethod)
             .WithOne(p => p.BankAccount)
             .HasForeignKey<PaymentMethod>(p => p.BankAccountId);
        }
    }
}