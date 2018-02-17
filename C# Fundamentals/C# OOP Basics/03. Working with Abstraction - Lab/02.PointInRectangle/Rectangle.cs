namespace _02.PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeft, Point bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }


        public bool Contains(Point point)
        {

            if ((TopLeft.X <= point.X) &&
                (TopLeft.Y <= point.Y) &&
                (BottomRight.X >= point.X) &&
                (BottomRight.Y >= point.Y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
