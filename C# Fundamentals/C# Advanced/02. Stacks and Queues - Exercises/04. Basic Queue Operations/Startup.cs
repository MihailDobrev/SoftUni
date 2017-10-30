namespace _04.Basic_Queue_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            int[] manipulationNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int enqueElements = manipulationNumbers[0];
            int dequeElements = manipulationNumbers[1];
            int elementToCheck = manipulationNumbers[2];

            Queue<int> numbers = new Queue<int>();

            int[] inputnumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int index = 0; index < enqueElements; index++)
            {
                numbers.Enqueue(inputnumbers[index]);
            }

            for (int i = 0; i < dequeElements; i++)
            {
                numbers.Dequeue();
            }

            if (numbers.Count>0)
            {
                if (numbers.Contains(elementToCheck))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numbers.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
           
        }
    }
}
