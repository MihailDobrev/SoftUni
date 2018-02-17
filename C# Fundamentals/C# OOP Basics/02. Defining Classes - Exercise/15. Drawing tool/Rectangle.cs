namespace _15.Drawing_tool
{
    using System;
    public class Rectangle:Figure
    {
        public Rectangle(int width, int length)
        {
            Width = width;
            Length = length;
        }

        public int Width { get; set; }
        public int Length { get; set; }

        public override void Draw()
        {
            string topAndBottom = '|' + new string('-', Width) + '|';
            Console.WriteLine(topAndBottom);
            for (int i = 0; i < Length - 2; i++)
            {
                Console.WriteLine('|' + new string(' ', Width) + '|');
            }
            Console.WriteLine(topAndBottom);
        }
    }
}
