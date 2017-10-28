namespace _03.Count_Same_Values_in_Array
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        public static void Main()
        {
            SortedDictionary<double, int> numbers = new SortedDictionary<double, int>();

            double[] numbersInput = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries ).Select(double.Parse).ToArray();
            

            foreach (double num in numbersInput)
            {
                if (!numbers.ContainsKey(num))
                {
                    numbers[num] = 1;
                }
                else
                {
                    numbers[num]++;
                }
            }

            foreach (var pair in numbers)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}
