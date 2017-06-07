namespace Max_Method
{
    using System;
    public class MaxMethod
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int maxNumber = GetMax(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine(maxNumber);
        }

        private static int GetMax(int firstNumber, int secondNumber, int thirdNumber)
        {
            int[] numbers = { firstNumber, secondNumber, thirdNumber };

            int maxNumber = -999999999;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                int tempMax = currentNumber;
                if (maxNumber < tempMax)
                {
                    maxNumber = tempMax;
                }
            }
            return maxNumber;
        }

        private static int GetMax(int firstNumber, int secondNumber)
        {
            if (firstNumber >= secondNumber)
            {
                return firstNumber;
            }
            else
            {
                return secondNumber;
            }
        }
    }
}
