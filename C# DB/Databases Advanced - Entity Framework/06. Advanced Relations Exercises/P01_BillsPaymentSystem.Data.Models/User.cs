namespace P01_BillsPaymentSystem.Data.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            PaymentMethods = new HashSet<PaymentMethod>();
        }
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }
    }
}
