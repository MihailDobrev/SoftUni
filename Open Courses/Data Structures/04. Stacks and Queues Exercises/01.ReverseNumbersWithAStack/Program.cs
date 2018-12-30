using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseNumbersWithAStack
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackNumbers = new Stack<int>();

            foreach (var number in numbers)
            {
                stackNumbers.Push(number);
            }

            while(stackNumbers.Count>0)
            {
                Console.Write(stackNumbers.Pop()+" ");
            }
        }
    }
}
