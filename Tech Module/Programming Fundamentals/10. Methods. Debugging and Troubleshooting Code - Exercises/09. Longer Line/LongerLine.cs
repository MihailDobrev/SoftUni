namespace Longer_Line
{
    using System;
    public class LongerLine
    {
        static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            PrintPointsOfLongerLines(x1, y1, x2, y2, x3, y3, x4, y4);
        }

        private static void PrintPointsOfLongerLines(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double distanceToFistPoint = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
            double distanceToSecondPoint = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));
            double distanceToThirdPoint = Math.Sqrt(Math.Pow(x3, 2) + Math.Pow(y3, 2));
            double distanceToFourthPoint = Math.Sqrt(Math.Pow(x4, 2) + Math.Pow(y4, 2));

            if (Math.Abs(distanceToFistPoint + distanceToSecondPoint) >= Math.Abs(distanceToThirdPoint + distanceToFourthPoint))
            {
                if (distanceToFistPoint <= distanceToSecondPoint)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }

            }
            else
            {
                if (distanceToThirdPoint <= distanceToFourthPoint)
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                else
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
            }
        }
    }
}
