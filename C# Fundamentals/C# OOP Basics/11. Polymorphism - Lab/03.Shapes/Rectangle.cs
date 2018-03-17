public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(double width, double height)
    {
        this.height = height;
        this.width = width;
    }

    public double Width
    {
        get { return width; }
        private set { width = value; }
    }

    public double Height
    {
        get { return height; }
        private set { height = value; }
    }

    public override double CalculateArea() => Height * Width;

    public override double CalculatePerimeter() => 2 * (Height + Width);

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}

