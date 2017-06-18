
namespace _5.Closest_Two_Points
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ClosestTwoPoints
    {
        static void Main()
        {

            int n = int.Parse(Console.ReadLine());
            var points = new List<Point>();

            for (int i = 0; i < n; i++)
            {
                var currentPointparts = Console.ReadLine()
                    .Split(' ')
                    .Select(double.Parse)
                    .ToArray();

                Point currentPoint = new Point { X = currentPointparts[0], Y = currentPointparts[1] };

                points.Add(currentPoint);

            }

            double minDistanceSoFar = double.MaxValue;
            Point firstPointMin = null;
            Point secondPointMin = null;

            for (int i = 0; i < points.Count - 1; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    Point firstPoint = points[i];
                    Point secondPoint = points[j];

                    var currentDistance = CalculateDistance(firstPoint, secondPoint);

                    if (currentDistance < minDistanceSoFar)
                    {
                        minDistanceSoFar = currentDistance;
                        firstPointMin = firstPoint;
                        secondPointMin = secondPoint;
                    }
                }
            }

            Console.WriteLine($"{minDistanceSoFar:F3}");
            Console.WriteLine($"({firstPointMin.X}, {firstPointMin.Y})");
            Console.WriteLine($"({secondPointMin.X}, {secondPointMin.Y})");
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
