namespace P03_UserDetails
{
    using P01_BillsPaymentSystem.Data;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BillsPaymentSystemContext())
            {
                int userIdToDisplay = GetUserId(context);

                GetUserAndDisplayInfo(context, userIdToDisplay);
            }
        }

        private static void GetUserAndDisplayInfo(BillsPaymentSystemContext context, int userIdToDisplay)
        {
            var usersWithPaymentInfo = context.Users
                .Where(u => u.UserId == userIdToDisplay)
                .Select(u => new
                {
                    Name = string.Concat(u.FirstName, " ", u.LastName),
                    BankAccountsIds = u.PaymentMethods.Select(pm => new
                    {
                        ID = pm.BankAccountId
                    }).ToArray(),
                    CreditCardsIds = u.PaymentMethods.Select(pm => new
                    {
                        ID = pm.CreditCardId
                    }).ToArray()
                }).ToArray();


            foreach (var user in usersWithPaymentInfo)
            {
                Console.WriteLine($"User: {user.Name}");

                Console.WriteLine("Bank Accounts:");
                foreach (var account in user.BankAccountsIds.Where(i => i.ID != null))
                {
                    int id = (int)account.ID;
                    Console.WriteLine($"--ID: {id}");
                    var bankAccount = context.BankAccounts.Find(id);

                    Console.WriteLine($"--- Balance: {bankAccount.Balance:F2}");
                    Console.WriteLine($"--- Bank: {bankAccount.BankName}");
                    Console.WriteLine($"--- SWIFT: {bankAccount.SWIFTCode}");

                }

                Console.WriteLine("Credit Cards:");
                foreach (var creditCard in user.CreditCardsIds.Where(i => i.ID != null))
                {
                    int id = (int)creditCard.ID;
                    Console.WriteLine($"--ID: {id}");
                    var card = context.CreditCards.Find(id);

                    Console.WriteLine($"--- Limit: {card.Limit:F2}");
                    Console.WriteLine($"--- Money Owed: {card.MoneyOwed:F2}");
                    Console.WriteLine($"--- Limit Left:: {card.LimitLeft:F2}");
                    Console.WriteLine($"--- Expiration Date: {card.ExpirationDate.Year}/{card.ExpirationDate.Month}");
                }
            }
        }

        public static int GetUserId(BillsPaymentSystemContext context)
        {
            int userIdToDisplay = int.Parse(Console.ReadLine());

            var userName = context.Users.Find(userIdToDisplay);

            if (userName == null)
            {
                Console.WriteLine($"User with id {userIdToDisplay} not found!");
                Environment.Exit(0);
            }

            return userIdToDisplay;
        }
    }
}
