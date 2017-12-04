namespace _04.Convert_from_base_10_to_base_N
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            BigInteger[] inputLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();
            BigInteger baseNumber = inputLine[0];
            BigInteger decimalNumber = inputLine[1];
            BigInteger reminder = 0;
            Stack<BigInteger> stack = new Stack<BigInteger>();
            StringBuilder sb = new StringBuilder();

            while (decimalNumber>0)
            {
                reminder = decimalNumber % baseNumber;
                stack.Push(reminder);
                decimalNumber = decimalNumber / baseNumber;
            }

            while (stack.Count>0)
            {
                sb.Append(stack.Pop());
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
