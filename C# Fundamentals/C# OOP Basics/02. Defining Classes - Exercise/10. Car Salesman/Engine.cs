namespace _10.Car_Salesman
{
    public class Engine
    {
        private string model;
        private int power;
        private string efficiency;
        private int powerDisplacement;
       
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }

        public Engine(string model, int power, int powerDisplacement) 
            : this(model, power)
        {
            PowerDisplacement = powerDisplacement;
        }

        public Engine(string model, int power, string efficiency) 
            : this(model, power)
        {
            Efficiency = efficiency;
        }

        public Engine(string model, int power, int powerDisplacement, string efficiency) 
            : this(model, power)
        {
            PowerDisplacement = powerDisplacement;
            Efficiency = efficiency;
        }

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }

        public int PowerDisplacement
        {
            get { return powerDisplacement; }
            set { powerDisplacement = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

    }
}
