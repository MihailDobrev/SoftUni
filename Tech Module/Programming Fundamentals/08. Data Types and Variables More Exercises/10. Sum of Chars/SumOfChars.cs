

namespace Sum_of_Chars
{
    using System;
  
    public class SumOfChars
    {
        static void Main()
        {
            byte numberOfLines = byte.Parse(Console.ReadLine());
            int sum = 0;

            for (int index = 0; index < numberOfLines; index++)
            {
                sum +=char.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
