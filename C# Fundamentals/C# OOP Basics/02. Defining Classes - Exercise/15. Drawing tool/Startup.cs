namespace _15.Drawing_tool
{
    using System;
    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            DrawingTool drawingTool = new DrawingTool();

            switch (input)
            {
                case "Square":
                    int side = int.Parse(Console.ReadLine());
                    Figure square = new Square(side);
                    drawingTool.DrawFigure(square);
                    break;
                case "Rectangle":
                    int width = int.Parse(Console.ReadLine());
                    int length = int.Parse(Console.ReadLine());
                    Figure rectangle = new Rectangle(width, length);
                    drawingTool.DrawFigure(rectangle);
                    break;
                default:
                    break;
            }

           
            
        }
    }
}
