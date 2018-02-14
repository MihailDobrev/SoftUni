namespace _01.Class_Box
{
    using System;
    using System.Text;

    public class Box
    {
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        private double length;
        private double width;
        private double height;

        public double Length
        {
            get { return length; }
            private set {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value; }
        }
    
        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }
    
        public double Height
        {
            get { return height; }
            private set {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value; }
        }


        public double CalculateSurfaceArea()
        {
            return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        public double CalculateLateralSurfaceArea()
        {
            return 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        public double CalculateVolume()
        {
            return this.Width * this.Length * this.Height;
        }

        public override string ToString()
        {
            double surfacaArea = CalculateSurfaceArea();
            double lateralSurfaceArea = CalculateLateralSurfaceArea();
            double volume = CalculateVolume();
            StringBuilder sb = new StringBuilder();
            sb.Append($"Surface Area - {surfacaArea:f2}{Environment.NewLine}");
            sb.Append($"Lateral Surface Area - {lateralSurfaceArea:f2}{Environment.NewLine}");
            sb.Append($"Volume - {volume:f2}");
            return sb.ToString();
        }
    }
}
