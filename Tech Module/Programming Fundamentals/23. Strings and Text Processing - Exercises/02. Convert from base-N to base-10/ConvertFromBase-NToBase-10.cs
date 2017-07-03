namespace _02.Convert_from_base_N_to_base_10
{
    using System;
    using System.Numerics;

    public class ConvertFromBaseNToBase10
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int baseNumber = int.Parse(input[0]);
            string numberInBase = input[1];
            BigInteger sum = 0;
            int counter = 0;

            for (int i = numberInBase.Length - 1; i >= 0; i--)
            {
                sum += int.Parse(numberInBase[i].ToString()) * BigInteger.Pow(baseNumber, counter);
                counter++;
            }
            Console.WriteLine(sum);
        }
    }
}
