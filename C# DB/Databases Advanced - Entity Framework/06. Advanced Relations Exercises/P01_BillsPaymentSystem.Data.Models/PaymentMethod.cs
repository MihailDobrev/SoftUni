namespace P01_BillsPaymentSystem.Data.Models
{
    using P01_BillsPaymentSystem.Data.Models.Attributes;

    public class PaymentMethod
    {
        public int Id { get; set; }

        public PaymentType Type { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }


        [Xor(nameof(BankAccountId))]
        public int? CreditCardId { get; set; }

        public virtual CreditCard CreditCard { get; set; }

        public int? BankAccountId { get; set; }

        public virtual BankAccount BankAccount { get; set; }

      
    }
}
