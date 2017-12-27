namespace _08.Custom_Comparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        public static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();

            for (int index = 0; index < numbers.Count; index++)
            {
                int currentNumber = numbers[index];

                if (IsEven(currentNumber, n => n % 2 == 0))
                {
                    evenNumbers.Add(currentNumber);
                }
                else
                {
                    oddNumbers.Add(currentNumber);
                }
            }

            evenNumbers = evenNumbers.OrderBy(x => x).ToList();
            oddNumbers = oddNumbers.OrderBy(x => x).ToList();
            numbers.Clear();
            numbers.AddRange(evenNumbers);
            numbers.AddRange(oddNumbers);
            Console.WriteLine(string.Join(" ",numbers));
        }

        private static bool IsEven(int currentNumber, Func<int, bool> condition) => condition(currentNumber);

    }
}
