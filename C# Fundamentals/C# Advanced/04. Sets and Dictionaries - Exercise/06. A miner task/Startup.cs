namespace _06.A_miner_task
{
    using System;
    using System.Collections.Generic;
    public class Startup
    {
        public static void Main()
        {
            string input = string.Empty;
            Dictionary<string, int> resourceRecords = new Dictionary<string, int>();

            input = Console.ReadLine();

            while (input!="stop")
            {
                string name = input;
                int quantity = int.Parse(Console.ReadLine());

                if (!resourceRecords.ContainsKey(name))
                {
                    resourceRecords[name] = quantity;
                }
                else
                {
                    resourceRecords[name] += quantity;
                }

                input = Console.ReadLine();
            }

            foreach (var resourceRecord in resourceRecords)
            {
                Console.WriteLine($"{resourceRecord.Key} -> {resourceRecord.Value}");
            }
        }
    }
}
