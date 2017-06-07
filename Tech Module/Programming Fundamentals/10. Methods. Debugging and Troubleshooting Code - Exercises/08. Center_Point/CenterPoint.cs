
namespace Center_Point
{
    using System;
 
    public class CenterPoint
    {
        static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            PrintClosestPoints(x1, y1, x2, y2);
        }

        private static void PrintClosestPoints(double x1, double y1, double x2, double y2)
        {
            double sumCoordinatesFistPoint = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
            double sumCoordinatesSecondPoint = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));

            if (sumCoordinatesFistPoint <= sumCoordinatesSecondPoint)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}
