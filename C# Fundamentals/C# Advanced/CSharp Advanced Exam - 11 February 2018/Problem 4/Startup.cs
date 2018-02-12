namespace Problem_4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int requiredTargetInfoIndex = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, string>> hitListRecords = new Dictionary<string, Dictionary<string, string>>();

            string input = Console.ReadLine();

            while (input != "end transmissions")
            {
                string[] data = input.Split(new char[] { '=', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

                string name = data[0];

                for (int index = 1; index < data.Length; index += 2)
                {
                    string key = data[index];
                    string value = data[index + 1];

                    if (!hitListRecords.ContainsKey(name))
                    {
                        hitListRecords[name] = new Dictionary<string, string>();
                    }

                    hitListRecords[name][key] = value;

                }

                input = Console.ReadLine();
            }

            string killOrder = Console.ReadLine();
            string target = killOrder.Substring(5);

            var searchedTarget = hitListRecords.Where(r => r.Key == target).FirstOrDefault();

            Console.WriteLine($"Info on {searchedTarget.Key}:");
            int totalInfoIndex = 0;

            foreach (var keyValuePair in searchedTarget.Value.OrderBy(t=>t.Key))
            {
                string key = keyValuePair.Key;
                string value = keyValuePair.Value;
                Console.WriteLine($"---{key}: {value}");
                int currentInfoIndex= key.Length + value.Length;
                totalInfoIndex += currentInfoIndex;
            }

            Console.WriteLine($"Info index: {totalInfoIndex}");

            if (totalInfoIndex>=requiredTargetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {requiredTargetInfoIndex-totalInfoIndex} more info.");
            }
        }
    }
}
