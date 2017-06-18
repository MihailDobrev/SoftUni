

namespace _02.Odd_Filter
{
    using System;
    using System.Linq;
    public class OddFilter
    {
        static void Main()
        {
            var intArray = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            
            intArray = intArray.Where(x => x % 2 == 0).ToArray();
            double average = intArray.Average();

            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i]>average)
                {
                    intArray[i]++;
                }
                else if(intArray[i]<=average)
                {
                    intArray[i]--;
                }
            }
            Console.WriteLine(string.Join(" ",intArray));
        }
    }
}
