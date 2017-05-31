

namespace _07.Exchange_Variable_Values
{
    using System;


    public class ExchangeVariableValues
    {
        static void Main()
        {
            int a = 5;
            int b = 10;

            int aOld = a;
            int aTemp = a;
            int bOld = b;
            a = b;
            b = aTemp;

            Console.WriteLine("Before:");
            Console.WriteLine($"a = {aOld}");
            Console.WriteLine($"b = {bOld}");
            Console.WriteLine("After:");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
        }
    }
}
