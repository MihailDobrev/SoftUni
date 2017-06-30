

namespace _01.Reverse_string
{
    using System;
    using System.Linq;

    public class ReverseString
    {
        static void Main()
        {
            var text = Console.ReadLine()
                    .Reverse()
                    .ToList();
            Console.WriteLine(string.Join("",text));
                    
        }
    }
}
