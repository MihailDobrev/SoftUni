namespace Numbers_in_Reversed_Order
{
    using System;

    public class NumbersInReversedOrder
    {
        static void Main()
        {
            string number = Console.ReadLine();
            PrintDigits(number);
        }

        private static void PrintDigits(string number)
        {
            char[] numberArray = number.ToCharArray();

            for (int i = numberArray.Length - 1; i >= 0; i--)
            {
                Console.Write(number[i]);
            }
        }
    }
}
