
namespace Cube_Properties
{
    using System;
    public class CubeProperties
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();

            switch (parameter)
            {
                case "face": CalculateFaceDiagonal(side); break;
                case "space": CalculateSpaceDiagonal(side); break;
                case "volume": CalculateVolume(side); break;
                case "area": CalculateArea(side); break;
                default:
                    break;
            }
        }

        private static void CalculateArea(double side)
        {
            double area = 6 * Math.Pow(side, 2);
            PrintOnConsole(area);
        }

        private static void CalculateVolume(double side)
        {
            double volume = Math.Pow(side, 3);
            PrintOnConsole(volume);
        }

        private static void CalculateSpaceDiagonal(double side)
        {
            double spaceDiagonal = Math.Sqrt(3 * Math.Pow(side, 2));
            PrintOnConsole(spaceDiagonal);
        }

        private static void CalculateFaceDiagonal(double side)
        {
            double faceDiagonal = Math.Sqrt(2 * Math.Pow(side, 2));
            PrintOnConsole(faceDiagonal);
        }

        private static void PrintOnConsole(double number)
        {
            Console.WriteLine($"{number:f2}");
        }
    }
}
