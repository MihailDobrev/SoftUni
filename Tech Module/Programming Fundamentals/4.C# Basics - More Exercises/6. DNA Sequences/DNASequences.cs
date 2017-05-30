

namespace _6.DNA_Sequences
{
    using System;
     

    public class DNASequences
    {
        static void Main(string[] args)
        {           

            char[] letters = new char[] { 'A', 'C', 'G', 'T' };
            int number = int.Parse(Console.ReadLine());
                       
            for (int firstLetter = 1; firstLetter <= 4; firstLetter++)
            {
                for (int secondLetter = 1; secondLetter <= 4; secondLetter++)
                {
                    for (int thirdLetter = 1; thirdLetter <= 4; thirdLetter++)
                    {

                        char symbol = firstLetter + secondLetter + thirdLetter >= number ? 'O' : 'X';                     
                        Console.Write($"{symbol}{letters[firstLetter-1]}{letters[secondLetter-1]}{letters[thirdLetter-1]}{symbol} ");
                        
                    }
                    Console.WriteLine();
                }

            }
        }
    }
}
