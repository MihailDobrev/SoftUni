
namespace _18.Different_Integers_Size
{
    using System;
    public class DifferentIntegersSize
    {
        static void Main()
        {
            string number = Console.ReadLine();
            string result = string.Empty;

            try
            {
                sbyte.Parse(number);
                result += "* sbyte\n";
            }
            catch {}

            try
            {
                byte.Parse(number);
                result += "* byte\n";
            }
            catch {}

            try
            {
                short.Parse(number);
                result += "* short\n";
            }
            catch{ }

            try
            {
                ushort.Parse(number);
                result += "* ushort\n";
            }
            catch {}

            try
            {
                int.Parse(number);
                result += "* int\n";
            }
            catch {}

            try
            {
                uint.Parse(number);
                result += "* uint\n";
            }
            catch{}

            try
            {
                long.Parse(number);
                result += "* long\n";
            }
            catch
            {
                Console.WriteLine($"{number} can't fit in any type");
                return;
            }

            Console.WriteLine($"{number} can fit in:\n" + result);
        }
    }
}
