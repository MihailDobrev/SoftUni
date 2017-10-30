namespace _01.Reverse_Numbers_with_a_Stack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class Startup
    {
        public static void Main()
        {
            Stack<int> numbers = new Stack<int>();
            Console.ReadLine()
                .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList()
                .ForEach(num => numbers.Push(num));

            int elements = numbers.Count;
            List<int> reversedNumbers = new List<int>();

            for (int i = 0; i < elements; i++)
            {
                reversedNumbers.Add(numbers.Pop());
            }

            Console.Write(string.Join(" ", reversedNumbers));
        }
    }
}
