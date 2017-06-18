namespace _05.Parking_Validation
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    public class ParkingValidation
    {
        static void Main()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            Dictionary<string, string> licensePlatesRegister = new Dictionary<string, string>();

            for (int line = 0; line < numberOfCommands; line++)
            {
                var input = Console.ReadLine()
                    .Split(' ');
                string command = input[0];
                string user = input[1];

                if (command == "register")
                {
                    string licensePlateNumber = input[2];
                    if (licensePlatesRegister.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {user}");
                    }
                    else
                    {
                        Match match = Regex.Match(licensePlateNumber, @"[A-Z]{2}[0-9]{4}[A-Z]{2}$");

                        if (!match.Success)
                        {
                            Console.WriteLine($"ERROR: invalid license plate {licensePlateNumber}");
                        }
                        else
                        {
                            if (licensePlatesRegister.ContainsValue(licensePlateNumber))
                            {
                                Console.WriteLine($"ERROR: license plate {licensePlateNumber} is busy");
                            }
                            else
                            {
                                licensePlatesRegister[user] = licensePlateNumber;
                                Console.WriteLine($"{user} registered {licensePlateNumber} successfully");
                            }
                        }
                    }
                }
                else if (command == "unregister")
                {
                    if (!licensePlatesRegister.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                    else
                    {
                        licensePlatesRegister.Remove(user);
                        Console.WriteLine($"user {user} unregistered successfully");
                    }
                }
            }

            foreach (var pair in licensePlatesRegister)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }
        }
    }
}
