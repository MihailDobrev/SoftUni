

namespace Calculate_Triangle_Area
{
    using System;

    public class Calculate_Triangle_Area
    {
        static void Main()
        {
            double triangleBase = double.Parse(Console.ReadLine());
            double triangleHeight = double.Parse(Console.ReadLine());

            double area = CalculateTriangleArea(triangleBase, triangleHeight);
            Console.WriteLine(area);
        }

        private static double CalculateTriangleArea(double triangleBase, double triangleHeight)
        {
            double area = triangleBase * triangleHeight / 2;
            return area;
        }
    }
}
