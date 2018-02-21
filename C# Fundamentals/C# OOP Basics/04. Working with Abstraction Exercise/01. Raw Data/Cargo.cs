namespace _01._Raw_Data
{
    public class Cargo
    {
        private int weight;
        private string type;

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

    }
}
