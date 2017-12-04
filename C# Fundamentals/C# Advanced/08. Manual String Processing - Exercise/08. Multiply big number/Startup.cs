namespace _08.Multiply_big_number
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            string firstNumber = Console.ReadLine().TrimStart(new char[] { '0' });

            int secondNumber = int.Parse(Console.ReadLine());

            if (firstNumber == "0" || secondNumber == 0 || firstNumber == string.Empty)
            {
                Console.WriteLine(0);
                return;
            }

            int product = 0;
            int numberInMind = 0;
            int remainder = 0;

            StringBuilder result = new StringBuilder();

            for (int index = firstNumber.Length - 1; index >= 0; index--)
            {
                product = (int.Parse(firstNumber[index].ToString()) * secondNumber + numberInMind);
                numberInMind = (product / 10);
                remainder = (product % 10);
                result.Append(remainder);

                if (index == 0 && numberInMind != 0)
                {
                    result.Append(numberInMind);
                }
            }

            var resultToCharArr = result.ToString().ToCharArray();
            Array.Reverse(resultToCharArr);

            Console.WriteLine(new string(resultToCharArr));
        }
    }
}
