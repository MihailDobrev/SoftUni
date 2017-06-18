using System;
using System.Linq;


namespace _6.Rectangle_Position
{
    public class RectanglePosition
    {
        static void Main()
        {
            var firstRectangle = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            var secondRectangle = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            Rectangle rectangleOne = new Rectangle()
            {
                Left = firstRectangle[0],
                Top = firstRectangle[1],
                Width = firstRectangle[2],
                Height = firstRectangle[3],
            };

            Rectangle rectangleTwo = new Rectangle()
            {
                Left = secondRectangle[0],
                Top = secondRectangle[1],
                Width = secondRectangle[2],
                Height = firstRectangle[3],
            };

            bool isInside=IsInside(rectangleOne, rectangleTwo);

            if (isInside)
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }
        }

        public static bool IsInside(Rectangle rectangleOne, Rectangle rectangleTwo)
        {
            bool isInside = false;

            if (rectangleOne.Left>=rectangleTwo.Left && 
                rectangleOne.Right<=rectangleTwo.Right &&
                rectangleOne.Top<=rectangleTwo.Top &&
                rectangleOne.Bottom<=rectangleTwo.Bottom)
            {
                isInside = true;
            }

            return isInside;
        }
    }
}
