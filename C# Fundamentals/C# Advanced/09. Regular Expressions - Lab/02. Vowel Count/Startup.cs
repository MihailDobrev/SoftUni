using System;
using System.Text.RegularExpressions;

namespace _02.Vowel_Count
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex regex = new Regex("[AEIOUYaeiouy]");

            Console.WriteLine($"Vowels: {regex.Matches(text).Count}");
        }
    }
}
