namespace Index_of_Letters
{
    using System;
    public class IndexOfLetters
    {
        static void Main()
        {

            string letters = Console.ReadLine();               

            for (int i = 0; i < letters.Length; i++)
            {
                int letterNumber = Convert.ToInt32(letters[i]) - 97;
                Console.WriteLine($"{letters[i]} -> {letterNumber}");
            }
        }

    }
}
