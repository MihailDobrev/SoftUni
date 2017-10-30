namespace _02.Basic_Stack_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] manipulationNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackOfNumbers = new Stack<int>();

            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int elementsToPush = manipulationNumbers[0];
            int elementsToPop = manipulationNumbers[1];
            int elementToCheck = manipulationNumbers[2];

            for (int i = 0; i < elementsToPush; i++)
            {
                stackOfNumbers.Push(numbers[i]);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                stackOfNumbers.Pop();
            }

            if (stackOfNumbers.Count>0)
            {
                if (stackOfNumbers.Contains(elementToCheck))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stackOfNumbers.Min());
                }
            }
            else
            {
                Console.WriteLine("0");
            }
           
        }
    }
}
