namespace MathPower
{
    using System;

    public class MathPower
    {
        static void Main()
        {
            double number = double.Parse(Console.ReadLine());
            double raisingNumber = double.Parse(Console.ReadLine());

            double returnedRaisedNumber = Pow(number, raisingNumber);
            Console.WriteLine(returnedRaisedNumber);
        }

        private static double Pow(double number, double raisingNumber)
        {
            double returnedRaisedNumber = 1;

            for (int i = 1; i <= raisingNumber; i++)
            {
                returnedRaisedNumber *= number;
            }
            return returnedRaisedNumber;
        }
    }
}
