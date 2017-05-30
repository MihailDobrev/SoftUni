

namespace _10.Triangle_of_Num
{
    using System;
    public class TriangleOfNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int number = 1;

            for (int row = 1; row <= n; row++)
            {
                for (int column = 1; column <= row; column++)
                {
                    Console.Write(number+ " ");                  
                }
                number++;
                Console.WriteLine();
            }
        }
    }
}
