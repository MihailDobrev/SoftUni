namespace _04.Pascal_Triangle
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            long[][] triangle = new long[size][];


            for (int rowIndex = 0; rowIndex < size; rowIndex++)
            {
                triangle[rowIndex] = new long[rowIndex + 1];
                triangle[rowIndex][0] = 1;
                triangle[rowIndex][rowIndex] = 1;

                for (int column = 1; column < rowIndex; column++)
                {
                    triangle[rowIndex][column] = triangle[rowIndex - 1][column - 1] + triangle[rowIndex - 1][column];
                }
            }

            var result = new StringBuilder();

            foreach (var row in triangle)
            {
                result.AppendLine(string.Join(" ", row));
            }

            Console.Write(result);
        }
    }
}
