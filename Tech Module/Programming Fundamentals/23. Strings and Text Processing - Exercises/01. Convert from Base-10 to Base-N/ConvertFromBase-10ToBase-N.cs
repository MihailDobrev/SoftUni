namespace _01.Convert_from_Base_10_to_Base_N
{
    using System;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    public class ConvertFromBase10toBaseN
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            BigInteger baseNumber = BigInteger.Parse(input[0]);
            BigInteger numberInDecimal = BigInteger.Parse(input[1]);
            StringBuilder sb = new StringBuilder();
            BigInteger remainder = 0;

            while (numberInDecimal > 0)
            {
                remainder = numberInDecimal % baseNumber;
                numberInDecimal /= baseNumber;
                sb.Append(remainder);
            }
            Console.WriteLine(string.Join("", (sb.ToString().Reverse().ToArray())));
        }
    }
}
