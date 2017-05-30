
namespace _14.Magic_Letter
{
    using System;


    public class MagicLetter
    {
        static void Main()
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            char excludedLetter = char.Parse(Console.ReadLine());

            for (char first = firstLetter; first <= secondLetter; first++)
            {
                for (char second = firstLetter; second <= secondLetter; second++)
                {
                    for (char third = firstLetter; third <= secondLetter; third++)
                    {
                        if (first!=excludedLetter && second!=excludedLetter && third!=excludedLetter)
                        {
                            Console.Write($"{first}{second}{third} ");
                        }
                    }
                }
            }
        }
    }
}
