namespace _01.Sum_Matrix_Elements
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] matrixDimensions = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixDimensions[0];
            int columns = matrixDimensions[1];
            int sum = 0;

            for (int i = 0; i < rows; i++)
            {
                int[] matrixInput = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                sum+=matrixInput.Sum();
            }

            Console.WriteLine(rows);
            Console.WriteLine(columns);
            Console.WriteLine(sum);
        }
    }
}
