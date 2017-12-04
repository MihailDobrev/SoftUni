namespace _02.String_Length
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            const byte maximumCharacters = 20;

            string text = Console.ReadLine();
            int textLenght = text.Length;

            if (textLenght< maximumCharacters)
            {
                string newText = text.PadRight(maximumCharacters, '*');
                Console.WriteLine(newText);
            }
            else
            {
                for (int index = 0; index < 20; index++)
                {
                    Console.Write(text[index]);
                }
            }
        }
    }
}
