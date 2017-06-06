

namespace House_Builder
{
    using System;

    public class HouseBuilder
    {
        static void Main()
        {
            long firstNumber = long.Parse(Console.ReadLine());
            long secondNumber = long.Parse(Console.ReadLine());
            long sum = firstNumber > sbyte.MaxValue ?
                firstNumber * 10 + secondNumber * 4 :
                 firstNumber * 4 + secondNumber * 10;
            Console.WriteLine(sum);
        }
    }
}
