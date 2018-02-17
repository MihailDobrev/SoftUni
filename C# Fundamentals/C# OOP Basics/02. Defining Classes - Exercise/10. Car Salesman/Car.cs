namespace _10.Car_Salesman
{
    using System;
    using System.Text;
    public class Car
    {
        private string model;
        private Engine engine;
        private string color;
        private int weight;
        

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;           
        }

        public Car(string model, Engine engine, int weight) 
            : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color) 
            : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) 
            : this(model, engine)
        {
            Weight = weight;
            Color = color;
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }


        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.model}: {Environment.NewLine}");
            sb.Append($"  {this.engine.Model}: {Environment.NewLine}");
            sb.Append($"    Power: {this.engine.Power}{Environment.NewLine}");
            if (this.engine.PowerDisplacement== -9999999)
            {
                sb.Append($"    Displacement: n/a {Environment.NewLine}");
            }
            else
            {
                sb.Append($"    Displacement: {this.engine.PowerDisplacement}{Environment.NewLine}");
            }            
            sb.Append($"    Efficiency: {this.engine.Efficiency}{Environment.NewLine}");
            if (this.weight == -9999999)
            {
                sb.Append($"  Weight: n/a {Environment.NewLine}");
            }
            else
            {
                sb.Append($"  Weight: {this.weight}{Environment.NewLine}");
            }
          
            sb.Append($"  Color: {this.color}");
            return sb.ToString(); 
        }
    }
}
