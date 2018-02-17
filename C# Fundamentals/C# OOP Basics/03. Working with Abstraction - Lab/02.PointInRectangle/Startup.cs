namespace _02.PointInRectangle
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Rectangle rectangle = ReadRectangle();
            string[] points = ReadPoints();
            CheckPointsAreInside(points,rectangle);

        }
         private static void CheckPointsAreInside(string[] points, Rectangle rectangle)
        {
            for (int index = 0; index < points.Length; index++)
            {
                int[] pointCoordinates=points[index].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Point point = new Point(pointCoordinates[0], pointCoordinates[1]);

                bool isPointInsideRectagle = rectangle.Contains(point);
                Console.WriteLine(isPointInsideRectagle);
            }
        }

        private static Rectangle ReadRectangle()
        {
            int[] pointArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int topLeftX = pointArgs[0];
            int topLeftY = pointArgs[1];
            Point topLeftPoint = new Point(topLeftX, topLeftY);
            int bottomRightX = pointArgs[2];
            int bottomRightY = pointArgs[3];
            Point bottomRightPoint = new Point(bottomRightX, bottomRightY);
            Rectangle rectangle = new Rectangle(topLeftPoint, bottomRightPoint);
            return rectangle;
        }

        private static string[] ReadPoints()
        {
           
            int numberOfPoints = int.Parse(Console.ReadLine());

            string[] points = new string[numberOfPoints];

            for (int index = 0; index < numberOfPoints; index++)
            {
                points[index] = Console.ReadLine();
            }

            return points;
        }
    }
}
