namespace P04_PayBills
{
    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Data.Models;
    using P03_UserDetails;
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            using (var context = new BillsPaymentSystemContext())
            {
                int userIdToDisplay = StartUp.GetUserId(context);
                decimal amount = decimal.Parse(Console.ReadLine());
                PayBills(userIdToDisplay, amount);
            }
        }

        private static void PayBills(int userId, decimal amount)
        {
            using (var context = new BillsPaymentSystemContext())
            {
                var userMoneyAmounts = context.Users
                    .Where(u => u.UserId == userId)
                    .Select(u => new decimal[]
                    {
                        u.PaymentMethods
                                    .Where(pm => pm.BankAccountId != null)
                                    .Sum(pm => pm.BankAccount.Balance),

                        u.PaymentMethods
                                    .Where(pm => pm.CreditCardId != null)
                                    .Sum(pm => pm.CreditCard.LimitLeft)
                    }).ToArray();

                BankAccount[] bankAccounts = context.PaymentMethods.Where(pm => pm.UserId == userId && pm.BankAccount != null).Select(u => u.BankAccount).OrderBy(a => a.BankAccountId).ToArray();

                CreditCard[] creditCards = context.PaymentMethods.Where(pm => pm.UserId == userId && pm.CreditCard != null).Select(pm => pm.CreditCard).OrderBy(cc => cc.CreditCardId).ToArray();


                decimal sumBankAccounts = userMoneyAmounts[0][0];
                decimal sumCreditCards = userMoneyAmounts[0][1];

                if (sumBankAccounts + sumCreditCards >= amount)
                {
                    foreach (var bankAccount in bankAccounts)
                    {
                        if (bankAccount.Balance > amount)
                        {
                            bankAccount.Withdraw(amount);
                            amount = 0;
                        }
                        else
                        {
                            amount -= bankAccount.Balance;
                            bankAccount.Withdraw(bankAccount.Balance);
                        }
                    }
                    foreach (var creditCard in creditCards)
                    {
                        if (creditCard.LimitLeft >= amount)
                        {
                            creditCard.Withdraw(amount);
                            amount = 0;
                        }
                        else
                        {
                            amount -= creditCard.LimitLeft;
                            creditCard.Withdraw(creditCard.LimitLeft);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Insufficient funds!");
                }

                context.SaveChanges();
            }
        }
    }
}
