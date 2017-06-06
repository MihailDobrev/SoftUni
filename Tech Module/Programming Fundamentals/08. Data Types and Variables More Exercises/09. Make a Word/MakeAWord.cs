
namespace Make_a_Word
{
    using System;

    public class MakeaWord
    {
        static void Main()
        {
            byte numberOfLines = byte.Parse(Console.ReadLine());
            char[] characters = new char[numberOfLines];

            for (int index = 0; index < numberOfLines; index++)
            {
                characters[index] = char.Parse(Console.ReadLine());
            }

            Console.WriteLine($"The word is: {string.Join("",characters)}");
        }
    }
}
