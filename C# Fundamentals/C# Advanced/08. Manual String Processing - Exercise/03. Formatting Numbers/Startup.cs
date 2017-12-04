namespace _03.Formatting_Numbers
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] numbers = Console.ReadLine()
                .Split(new char[] {' ','\t'}, StringSplitOptions.RemoveEmptyEntries);
            int firstNum = int.Parse(numbers[0]);
            double secondNum = double.Parse(numbers[1]);
            double thirdNum = double.Parse(numbers[2]);

            string firstColumn = '|' + string.Format("{0:X}", firstNum).PadRight(10, ' ') + '|';
            string secondColumn = Convert.ToString(firstNum, 2).PadLeft(10, '0').Substring(0,10);
            string thirdColumn = '|' + string.Format("{0:f2}", secondNum).PadLeft(10, ' ');
            string fourthColumn = '|' + string.Format("{0:f3}", thirdNum).PadRight(10, ' ') + '|';

            Console.WriteLine(firstColumn+secondColumn+thirdColumn+fourthColumn);
        }
    }
}
