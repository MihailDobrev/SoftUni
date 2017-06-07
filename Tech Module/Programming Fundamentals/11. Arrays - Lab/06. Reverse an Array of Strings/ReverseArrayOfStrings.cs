namespace Reverse_an_Array_of_Strings
{
    using System;
    using System.Linq;
    public class ReverseArrayOfStrings
    {
        static void Main()
        {
            string[] array = Console.ReadLine()
                .Split(new char[] { ' ' })
                .Select(x => Convert.ToString(x))
                .ToArray();

            var reversedArray = array.Reverse();

            foreach (var symbol in reversedArray)
            {
                Console.Write(symbol + " ");
            }
        }
    }
}
