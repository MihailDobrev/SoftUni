namespace _07.Multiply_big_number
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class MultiplyBigNumber
    {
        static void Main()
        {
            var firstNumber = Console.ReadLine().TrimStart(new char[] { '0' });

            var secondNumber = int.Parse(Console.ReadLine());

            if (firstNumber == "0" || secondNumber == 0 || firstNumber == string.Empty)
            {
                Console.WriteLine(0);
                return;
            }

            var product = 0;
            var numberInMind = 0;
            var remainder = 0;

            var result = new StringBuilder();

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                product = (int)(int.Parse(firstNumber[i].ToString()) * secondNumber + numberInMind);
                numberInMind = (int)(product / 10);
                remainder = (int)(product % 10);
                result.Append(remainder);

                if (i == 0 && numberInMind != 0)
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
