namespace _3.Sum__Min__Max__Average
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class SumMinMaxAverage
    {
        static void Main()
        {
            int numbers = int.Parse(Console.ReadLine());

            int sum = 0;
            List<int> nums = new List<int>();
            
            for (int i = 0; i < numbers; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
                nums.Add(number);
            }
            
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Min = {nums.Min()}");
            Console.WriteLine($"Max = {nums.Max()}");
            Console.WriteLine($"Average = {nums.Average()}");
        }
    }
}
