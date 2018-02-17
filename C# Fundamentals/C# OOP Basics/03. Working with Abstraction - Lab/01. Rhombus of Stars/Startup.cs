namespace _01._Rhombus_of_Stars
{
    using System;
    public class Startup
    {
        public static void Main()
        {
            PrintRow(int.Parse(Console.ReadLine()));
        }

        private static void PrintRow(int stars)
        {
            int spaces = stars - 1;
            int starCounter = 1;

            while (spaces > 0)
            {
                Console.WriteLine(new string(' ', spaces) + string.Join(' ', new string('*', starCounter).ToCharArray()) + new string(' ', spaces));
                spaces--;
                starCounter++;
            }

            while (stars > 0)
            {
                Console.WriteLine(new string(' ', spaces) + string.Join(' ', new string('*', stars).ToCharArray()) + new string(' ', spaces));
                stars--;
                spaces++;
            }

        }
    }
}
