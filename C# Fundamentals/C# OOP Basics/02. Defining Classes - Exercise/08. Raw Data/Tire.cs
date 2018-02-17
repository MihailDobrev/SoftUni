namespace _08.Raw_Data
{
    public class Tire
    {
        private double pressure;
        private int age;

        public Tire(double pressure, int age)
        {
            Pressure = pressure;
            Age = age;
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }

    }
}
