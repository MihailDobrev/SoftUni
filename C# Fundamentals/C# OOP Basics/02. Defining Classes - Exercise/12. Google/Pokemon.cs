namespace _12.Google
{
    public class Pokemon
    {
        private string name;
        private string type;

        public Pokemon(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
