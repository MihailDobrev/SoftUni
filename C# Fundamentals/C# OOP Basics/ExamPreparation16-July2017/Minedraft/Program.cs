using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        PrintOutput();      
    }

    private static void PrintOutput()
    {
        DraftManager draftManager = new DraftManager();

        string inputLine;

        while ((inputLine = Console.ReadLine()) != "Shutdown")
        {
            List<string> commandArgs = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string commandName = commandArgs[0];

            commandArgs.RemoveAt(0);
            switch (commandName)
            {
                case "RegisterHarvester":
                    Console.WriteLine(draftManager.RegisterHarvester(commandArgs));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(draftManager.RegisterProvider(commandArgs));
                    break;
                case "Day":
                    Console.WriteLine(draftManager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(draftManager.Mode(commandArgs));
                    break;
                case "Check":
                    Console.WriteLine(draftManager.Check(commandArgs));
                    break;
            }
        }
        Console.WriteLine(draftManager.ShutDown());
    }
}

