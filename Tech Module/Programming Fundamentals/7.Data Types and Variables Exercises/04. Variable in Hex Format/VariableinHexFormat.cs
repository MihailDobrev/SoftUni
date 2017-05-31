
namespace _04.Variable_in_Hex_Format
{
    using System;

    public class VariableinHexFormat
    {
        public static void Main()
        {
            string hexadecimalNumber = Console.ReadLine();
            decimal convertedNumber = Convert.ToInt32(hexadecimalNumber, 16);
            Console.WriteLine(convertedNumber);
        }
    }
}
