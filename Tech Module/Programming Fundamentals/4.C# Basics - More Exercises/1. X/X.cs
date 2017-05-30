
namespace _1.X
{
    using System;

    public class X
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int firstAndLastSpaces = 0;
            int spaces = n - 2;

            //top of X figure

            for (int i = 1; i <= n/2; i++)
            {
                Console.Write(new string(' ', firstAndLastSpaces));
                Console.Write(new string('x',1));
                Console.Write(new string(' ',spaces));
                Console.Write(new string('x', 1));
                Console.WriteLine(new string(' ', firstAndLastSpaces));
                spaces -= 2;
                firstAndLastSpaces++;
            }

            //middle 

            Console.Write(new string(' ', firstAndLastSpaces));
            Console.Write(new string('x', 1));
            Console.WriteLine(new string(' ', firstAndLastSpaces));
           
            //bottom of X figure

            firstAndLastSpaces--;
            spaces = 1;

            for (int i = 1; i <= n/2; i++)
            {
                Console.Write(new string(' ', firstAndLastSpaces));
                Console.Write(new string('x', 1));
                Console.Write(new string(' ', spaces));
                Console.Write(new string('x', 1));
                Console.WriteLine(new string(' ', firstAndLastSpaces));
                spaces += 2;
                firstAndLastSpaces--;
            }
            
        }
    }
}
