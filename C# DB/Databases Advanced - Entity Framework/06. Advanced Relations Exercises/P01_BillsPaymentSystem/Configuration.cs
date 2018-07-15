namespace P01_BillsPaymentSystem.Data
{
    using P01_BillsPaymentSystem.Data.Models;
    using System;
    using System.Collections.Generic;

    public class Configuration
    {
        public const string ConnectionString = "Server = (localdb)\\MSSQLLocalDB; Database= BillsPaymentSystem; Integrated Security = True";

        public static void Seed(BillsPaymentSystemContext context)
        {
            AddUsers(context);
            AddCreditCards(context);
            AddBankAccounts(context);
            AddPaymentMethods(context);

            Console.WriteLine("Data successfully added");
        }

        private static void AddPaymentMethods(BillsPaymentSystemContext context)
        {
            var paymentMethods = new List<PaymentMethod>()
            {
                new PaymentMethod(){  UserId = 2, BankAccountId= 1,  Type= PaymentType.BankAccount  },
                new PaymentMethod(){  UserId = 2, BankAccountId= 2,  Type= PaymentType.BankAccount  },
                new PaymentMethod(){  UserId = 2, CreditCardId= 1,  Type= PaymentType.CreditCard  }
            };

            context.PaymentMethods.AddRange(paymentMethods);

            context.SaveChanges();
        }

        private static void AddBankAccounts(BillsPaymentSystemContext context)
        {
            var bankAccounts = new List<BankAccount>()
            {
                new BankAccount(){  Balance=2000, BankName = "Unicredit Bulbank", SWIFTCode = "UNCRBGSF" },
                new BankAccount(){  Balance=1000, BankName = "First Investment Bank", SWIFTCode = "FINVBGSF" },
                new BankAccount(){  Balance=3500, BankName = "UBB", SWIFTCode = "UBBBGSF" }
            };
            context.BankAccounts.AddRange(bankAccounts);
            context.SaveChanges();
        }

        private static void AddCreditCards(BillsPaymentSystemContext context)
        {
            var creditCards = new List<CreditCard>()
            {
                new CreditCard(){ Limit= 800, MoneyOwed=100, ExpirationDate= new DateTime(2020,03,1) },
                new CreditCard(){ Limit= 2600, MoneyOwed=700, ExpirationDate= new DateTime(2021,09,1) },
                new CreditCard(){ Limit= 1400, MoneyOwed=1100, ExpirationDate= new DateTime(2025,05,1) }
            };
            context.CreditCards.AddRange(creditCards);
            context.SaveChanges();
        }

        private static void AddUsers(BillsPaymentSystemContext context)
        {
            var users = new List<User>()
            {
                new User(){  FirstName = "Gosho",  LastName = "Petrov", Email= "goshopeshov478@mail.bg", Password = "secret123" },
                new User(){  FirstName = "Guy",  LastName = "Gilbert", Email= "guygilbert123@abv.bg", Password = "somethingSpecial" },
                new User(){  FirstName = "Ivan",  LastName = "Stankov", Email= "ivan1_stankov@yahoo.com", Password = "noneOfYourBusiness" }
            };
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
