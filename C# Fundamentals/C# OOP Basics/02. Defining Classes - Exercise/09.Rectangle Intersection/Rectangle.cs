namespace _09.Rectangle_Intersection
{
    public class Rectangle
    {
        public Rectangle(string iD, double width, double height, double topLeftCornerHorizontal, double topLeftCornerVertical)
        {
            ID = iD;
            Width = width;
            Height = height;
            TopLeftCornerHorizontal = topLeftCornerHorizontal;
            TopLeftCornerVertical = topLeftCornerVertical;
        }

        private string id;
        private double width;
        private double height;
        private double topLeftCornerHorizontal;
        private double topLeftCornerVertical;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public double Width 
        {
            get { return width; }
            set { width = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        

        public double TopLeftCornerHorizontal
        {
            get { return topLeftCornerHorizontal; }
            set { topLeftCornerHorizontal = value; }
        }

        public double TopLeftCornerVertical
        {
            get { return topLeftCornerVertical; }
            set { topLeftCornerVertical = value; }
        }

        public double BottomRightCornerHorizontal
        {
            get { return this.topLeftCornerHorizontal+this.width; }          
        }

        public double BottomRightCornerVertical
        {
            get { return this.topLeftCornerVertical-this.height; }
        }

        public bool DoesIntersect(Rectangle rectangle)
        {
           
            if ((this.TopLeftCornerHorizontal>rectangle.BottomRightCornerHorizontal) ||
                (this.BottomRightCornerHorizontal<rectangle.TopLeftCornerHorizontal) ||
                (this.TopLeftCornerVertical<rectangle.BottomRightCornerVertical) ||
                (this.BottomRightCornerVertical>rectangle.TopLeftCornerVertical))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
           
    }
}
