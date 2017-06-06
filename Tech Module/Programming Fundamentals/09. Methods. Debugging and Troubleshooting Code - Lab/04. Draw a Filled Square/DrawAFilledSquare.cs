namespace Draw_a_Filled_Square
{
    using System;

    public class DrawAFilledSquare
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            PrintDashes(n);
            PrintJaggedPart(n);
            PrintDashes(n);
        }

        private static void PrintJaggedPart(int n)
        {
            for (int i = 1; i <= n - 2; i++)
            {
                Console.Write("-");
                for (int k = 1; k <= n - 1; k++)
                {
                    Console.Write("\\/");
                }
                Console.WriteLine("-");
            }
        }

        private static void PrintDashes(int n)
        {
            Console.WriteLine(new string('-', 2 * n));
        }
    }
}
