namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(cc => cc.CreditCardId);
            builder.Property(cc => cc.Limit)
                .IsRequired();

            builder.Property(cc => cc.MoneyOwed)
                .IsRequired();

            builder.Ignore(cc => cc.LimitLeft);

            builder.Property(cc => cc.ExpirationDate)
                .IsRequired();

            builder.HasOne(cc => cc.PaymentMethod)
                .WithOne(p => p.CreditCard)
                .HasForeignKey<PaymentMethod>(p => p.CreditCardId);
        }
    }
}