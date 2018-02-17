namespace _15.Drawing_tool
{
    using System;
    public class Square:Figure
    {
        public Square(int side)
        {
            Side = side;
        }

        public int Side { get; set; }

        public override void Draw()
        {
            string topAndBottom = '|' + new string('-', Side) + '|';
            Console.WriteLine(topAndBottom);
            for (int i = 0; i < Side-2; i++)
            {
                Console.WriteLine('|' + new string(' ', Side) + '|');
            }
            Console.WriteLine(topAndBottom);
        }
    }
}
