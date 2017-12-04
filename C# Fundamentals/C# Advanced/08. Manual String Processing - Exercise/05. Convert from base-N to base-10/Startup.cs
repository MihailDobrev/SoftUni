namespace _05.Convert_from_base_N_to_base_10
{
    using System;
    using System.Numerics;

    public class Startup
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int baseNumber = int.Parse(input[0]);
            string numberInBase = input[1];
            BigInteger sum = 0;
            int counter = 0;

            for (int index = numberInBase.Length - 1; index >= 0; index--)
            {
                sum += int.Parse(numberInBase[index].ToString()) * BigInteger.Pow(baseNumber, counter);
                counter++;
            }
            Console.WriteLine(sum);
        }
    }
}
