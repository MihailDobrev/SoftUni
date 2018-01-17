
using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

        string command;

        while ((command=Console.ReadLine())!="End")
        {
            var cmdArgs = command.Split();
            var cmdType = cmdArgs[0];

            switch (cmdType)
            {
                case "Create": Create(cmdArgs, accounts);break;
                case "Deposit": Deposit(cmdArgs, accounts); break;
                case "Withdraw": Withdraw(cmdArgs, accounts); break;
                case "Print": Print(cmdArgs, accounts); break;
               
                default:
                    break;
            }
        }
    }

    private static void Print(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            Console.WriteLine($"Account ID{accounts[id].ID}, balance {accounts[id].Balance:f2}");
        }

        
    }

    private static void Withdraw(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        var sumToWitdraw = int.Parse(cmdArgs[2]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            if (accounts[id].Balance < sumToWitdraw)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                accounts[id].Balance -= sumToWitdraw;
            }
        }

    }

    private static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        var sumToDeposit = int.Parse(cmdArgs[2]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            accounts[id].Balance += sumToDeposit;
        }
    }

    private static void Create(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            var acc = new BankAccount();
            acc.ID = id;
            accounts.Add(id, acc);
        }
    }
}

