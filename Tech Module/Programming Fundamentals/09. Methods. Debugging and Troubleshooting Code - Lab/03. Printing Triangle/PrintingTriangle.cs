namespace Printing_Triangle
{
    using System;

    public class PrintingTriangle
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            PrintTriangle(n);
        }

        private static void PrintTriangle(int n)
        {
            for (int row = 1; row <= n; row++)
            {
                PrintColumn(row);
            };

            for (int row = n - 1; row >= 1; row--)
            {
                PrintColumn(row);
            }
        }

        private static void PrintColumn(int rowNumber)
        {
            for (int col = 1; col <= rowNumber; col++)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();
        }
    }
}
