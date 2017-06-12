
namespace _1.Remove_Negatives_and_Reverse
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveNegativesAndReverse
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            List<int> newList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i]>0)
                {
                    newList.Add(numbers[i]);
                }
            }

            newList.Reverse();

            if (newList.Count>0)
            {
                foreach (var number in newList)
                {
                    Console.Write(number + " ");
                }
            }
            else
            {
                Console.WriteLine("empty");
            }
            

        }
    }
}
