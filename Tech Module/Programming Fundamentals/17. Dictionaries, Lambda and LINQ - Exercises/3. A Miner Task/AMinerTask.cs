
namespace _3.A_Miner_Task
{
    using System;
    using System.Collections.Generic;

    public class AMinerTask
    {
        public static void Main()
        {
            string input;
            Dictionary<string, double> resources = new Dictionary<string, double>();

            while ((input = Console.ReadLine()) != "stop")
            {
                if (resources.ContainsKey(input))
                    resources[input] += double.Parse(Console.ReadLine());
                else
                    resources[input] = double.Parse(Console.ReadLine());
            }
            foreach (var pair in resources)
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
        }
    }
}
