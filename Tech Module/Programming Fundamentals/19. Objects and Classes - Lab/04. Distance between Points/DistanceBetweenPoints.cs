

namespace _04.Distance_between_Points
{
    using System;
    using System.Linq;


    public class DistanceBetweenPoints
    {
        static void Main()
        {
            var firstPointCoordinates = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            var secondPointCoordinates = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();


            Point point1 = new Point() { X = firstPointCoordinates[0], Y = firstPointCoordinates[1] };

            Point point2 = new Point() { X = secondPointCoordinates[0], Y = secondPointCoordinates[1] };

            double result = CalculateDistance(point1, point2);

            Console.WriteLine(Math.Round(result,3));
        }
        private static double CalculateDistance(Point firstpoint, Point secondPoint)
        {
            double differenceX = firstpoint.X - secondPoint.X;
            double differenceY = firstpoint.Y - secondPoint.Y;

            double powX = Math.Pow(differenceX, 2);
            double powY = Math.Pow(differenceY, 2);

            return Math.Sqrt(powX + powY);
        }


    }
}
