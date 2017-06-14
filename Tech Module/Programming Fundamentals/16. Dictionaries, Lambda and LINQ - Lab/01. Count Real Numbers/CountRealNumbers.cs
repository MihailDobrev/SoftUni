namespace _1.Count_Real_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountRealNumbers
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            var dictionary = new SortedDictionary<double, int>();

            foreach (var number in numbers)
            {

                if (dictionary.ContainsKey(number))
                {
                    dictionary[number]++;
                }
                else
                {
                    dictionary[number] = 1;
                }
            }
            foreach (var number in dictionary)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }

        }

    }
}
