namespace Reverse_Array_of_Integers
{
    using System;

    class ReverseAnArrayOfIntegers
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int[] numbers = new int[number];
            int counterOfReversedArray = numbers.Length - 1;

            for (int i = 0; i < number; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int[] reversedArray = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                reversedArray[counterOfReversedArray] = numbers[i];
                counterOfReversedArray--;
            }

            foreach (var num in reversedArray)
            {
                Console.Write(num + " ");
            }
        }
    }
}
