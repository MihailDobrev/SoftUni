namespace _06.Byte_Flip
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class ByteFlip
    {
        static void Main()
        {
            var input=Console.ReadLine()
                .Split(' ')
                .Where(x => x.Length == 2)
                .ToList();

            var reversedList = new List<string>();
            
            foreach (var number in input)
            {
                string reversedNumber=string.Concat(number.Reverse());
                reversedList.Add(reversedNumber);
            }
            reversedList.Reverse();

            List<char> word = new List<char>();

            foreach (var num in reversedList)
            {
                char character = (char)Convert.ToInt32(num,16);
                word.Add(character);
            }

            Console.WriteLine(string.Join("",word));
        }
    }
}
