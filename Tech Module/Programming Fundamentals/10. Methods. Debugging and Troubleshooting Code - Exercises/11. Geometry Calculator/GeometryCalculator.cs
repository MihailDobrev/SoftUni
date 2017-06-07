
namespace Geometry_Calculator
{
    using System;
    public class GeometryCalculator
    {
        static void Main()
        {
            string figureType = Console.ReadLine();


            switch (figureType)
            {
                case "triangle":
                    double triangleSide = double.Parse(Console.ReadLine());
                    double triangleHeight = double.Parse(Console.ReadLine());
                    double triangleArea=CalculateTriangleArea(triangleSide,triangleHeight);
                    PrintResult(triangleArea);
                    break;
                case "square":
                    double squareSide = double.Parse(Console.ReadLine());
                    double squareArea = CalculateSquareArea(squareSide);
                    PrintResult(squareArea);
                    break;
                case "rectangle":
                    double rectangleWidth = double.Parse(Console.ReadLine());
                    double rectangleHeight = double.Parse(Console.ReadLine());
                    double rectangleArea = CalculateRectangleArea(rectangleWidth, rectangleHeight);
                    PrintResult(rectangleArea);
                    break;
                case "circle":
                    double radius = double.Parse(Console.ReadLine());
                    double circleArea = CalculateCircleArea(radius);
                    PrintResult(circleArea);
                    break;
                default:
                    break;
            }
        }

        private static double CalculateRectangleArea(double rectangleWidth, double rectangleHeight)
        {
            double rectangleArea = rectangleWidth * rectangleHeight;
            return rectangleArea;
        }

        private static double CalculateSquareArea(double squareSide)
        {
            double squareArea = Math.Pow(squareSide, 2);
            return squareArea;
        }

        private static double CalculateCircleArea(double radius)
        {
            double circleArea = Math.PI * Math.Pow(radius, 2);
            return circleArea;
        }


        private static double CalculateTriangleArea(double triangleSide, double triangleHeight)
        {
            double triangleArea = triangleSide * triangleHeight / 2.00;
            return triangleArea;
        }
        
        private static void PrintResult(double result)
        {
            Console.WriteLine($"{result:F2}");
        }

    }
}
