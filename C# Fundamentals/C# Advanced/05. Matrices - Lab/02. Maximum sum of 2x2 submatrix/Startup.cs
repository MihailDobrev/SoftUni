namespace _02.Maximum_sum_of_2x2_submatrix
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

            int[][] matrix = new int[rows][];

            for (int index = 0; index < rows; index++)
            {
                matrix[index]=Console.ReadLine()
                  .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();   
            }

            int currentSum = 0;
            int maxMatrixSum = 0;
            int firstElementSubmatrixRowIndex = 0;
            int firstElementSubmatrixColumnIndex = 0;

            for (int row = 0; row < rows-1; row++)
            {
                for (int column = 0; column < columns-1; column++)
                {
                    currentSum = matrix[row][column] +
                               matrix[row][column + 1] +
                               matrix[row + 1][column] +
                               matrix[row + 1][column + 1];

                    if (currentSum>maxMatrixSum)
                    {
                        maxMatrixSum = currentSum;
                        firstElementSubmatrixRowIndex = row;
                        firstElementSubmatrixColumnIndex = column;
                    }
                }
            }

            for (int row = firstElementSubmatrixRowIndex; row < firstElementSubmatrixRowIndex+2; row++)
            {
                for (int column = firstElementSubmatrixColumnIndex; column < firstElementSubmatrixColumnIndex+2; column++)
                {
                    Console.Write(matrix[row][column]+" ");
                }
                Console.WriteLine();
            }            
            Console.WriteLine(maxMatrixSum);
        }
    }
}
