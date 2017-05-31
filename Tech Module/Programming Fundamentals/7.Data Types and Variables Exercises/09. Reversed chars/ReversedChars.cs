


namespace _09.Reversed_chars
{
    using System;
    public class ReversedChars
    {
        static void Main()
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            char thirdLetter = char.Parse(Console.ReadLine());

            Console.WriteLine($"{thirdLetter}{secondLetter}{firstLetter}");

        }
    }
}
