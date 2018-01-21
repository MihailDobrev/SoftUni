namespace _11.Pokemon_Trainer
{
    public class Pokemon
    {
        private string name;
        private string element;
        private int health;

        public Pokemon(string name, string element, int health)
        {
            this.name = name;
            this.element = element;
            this.health = health;
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }


        public string Element
        {
            get { return element; }
            set { element = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
