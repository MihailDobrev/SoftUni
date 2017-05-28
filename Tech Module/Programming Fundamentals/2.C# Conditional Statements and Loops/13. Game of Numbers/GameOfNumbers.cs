

namespace _13.Game_of_Numbers
{
    using System;

    public class GameOfNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magicalNumber = int.Parse(Console.ReadLine());
            bool numberFound=false;
            int firstNumber = 0;
            int secondNumber = 0;
            int counter = 0;

            for (firstNumber = m; firstNumber >= n; firstNumber--)
            {
                for (secondNumber = m; secondNumber >= n; secondNumber--)
                {
                    counter++;
                    if (firstNumber + secondNumber == magicalNumber)
                    {
                        numberFound = true;
                        break;
                    }
                }
                if (numberFound)
                {
                    break;
                }
            }
            if (numberFound)
            {
                Console.WriteLine($"Number found! {firstNumber} + {secondNumber} = {magicalNumber}");
            }
            else
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicalNumber}");
            }
        }

        
    }
}
