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
            this.model = model;
            this.power = power;
        }

        public Engine(string model, int power, int powerDisplacement) 
            : this(model, power)
        {
            this.powerDisplacement = powerDisplacement;
        }

        public Engine(string model, int power, string efficiency) 
            : this(model, power)
        {
            this.efficiency = efficiency;
        }

        public Engine(string model, int power, int powerDisplacement, string efficiency) 
            : this(model, power)
        {
            this.powerDisplacement = powerDisplacement;
            this.efficiency = efficiency;
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
