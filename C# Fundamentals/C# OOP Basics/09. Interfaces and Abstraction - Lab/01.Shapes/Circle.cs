public class Circle : IDrawable
{
    public Circle(int radius)
    {
        Radius = radius;
    }

    private int radius;

    public int Radius
    {
        get { return radius; }
        private set { radius = value; }
    }

    public void Draw()
    {
    }
}
