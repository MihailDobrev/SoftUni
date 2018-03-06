public class Rectangle : IDrawable
{
    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    private int width;
    private int height;

    public int Height
    {
        get { return height; }
        private set { height = value; }
    }

    public int Width
    {
        get { return width; }
        private set { width = value; }
    }

    public void Draw()
    {     
    }
}

