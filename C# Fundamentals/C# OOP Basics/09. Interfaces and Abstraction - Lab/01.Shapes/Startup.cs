using System;

public class Startup
{
    private Type sut = typeof(Circle);

    public static void Main()
    {
        int radius = int.Parse(Console.ReadLine());
        IDrawable circle = new Circle(radius);

        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());

        IDrawable rect = new Rectangle(width, height);

        circle.Draw();
        rect.Draw();
    }
}

