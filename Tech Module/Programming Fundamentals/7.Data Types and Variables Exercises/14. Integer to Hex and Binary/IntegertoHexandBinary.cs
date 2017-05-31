
namespace _14_Integer_to_Hex_and_Binary
{
    using System;

    public class IntegertoHexandBinary
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            string hexadecimal = number.ToString("X");

            string binary = Convert.ToString(number, 2);

            Console.WriteLine(hexadecimal);

            Console.WriteLine(binary);
        }
    }
}
