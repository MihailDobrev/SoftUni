
namespace IntersectionCircles
{
    using System;
    using System.Linq;

    public class IntersectionofCircles
    {
        static void Main()
        {
            Circle firstCircle = ReadCircle(Console.ReadLine());
            Circle secondCircle = ReadCircle(Console.ReadLine());
            double diameter = CalculateDiameter(firstCircle,secondCircle);

            if (diameter<=firstCircle.Radius+secondCircle.Radius)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        public static double CalculateDiameter(Circle firstCircle, Circle secondCircle)
        {
            double diffX = Math.Pow((firstCircle.Center.X - secondCircle.Center.X), 2);
            double diffY = Math.Pow((firstCircle.Center.Y - secondCircle.Center.Y), 2);
            var diameter = Math.Sqrt(diffX + diffY);
            return diameter;
        }

        public static Circle ReadCircle(string input)
        {
            var properties = input.Split(' ').Select(int.Parse).ToArray();
            var circle = new Circle() { Center = new Center() { X = properties[0], Y = properties[1] }, Radius = properties[2] };
            return circle;
        }
    }
}
