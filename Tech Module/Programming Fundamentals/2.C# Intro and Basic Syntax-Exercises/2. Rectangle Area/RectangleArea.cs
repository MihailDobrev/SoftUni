
namespace _2.Rectangle_Area
{
    using System;
    public class RectangleArea
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine($"{width * height:F2}");
        }
    }
}
