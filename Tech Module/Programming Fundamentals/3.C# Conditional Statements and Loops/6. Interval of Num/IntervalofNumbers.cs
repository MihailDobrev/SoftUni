
namespace _6.Interval_of_Num
{
    using System;
     public class IntervalOfNumbers
    {
        static void Main()
        {
            byte firstNumber = byte.Parse(Console.ReadLine());
            byte secondNumber = byte.Parse(Console.ReadLine());
            byte biggerNumber = 0;
            byte smallerNumber = 0;

            biggerNumber = firstNumber > secondNumber ? firstNumber : secondNumber;
            smallerNumber = firstNumber < secondNumber ? firstNumber : secondNumber;

            for (int index = smallerNumber; index <= biggerNumber; index++)
            {
                Console.WriteLine(index);
            }
        }
    }
}
