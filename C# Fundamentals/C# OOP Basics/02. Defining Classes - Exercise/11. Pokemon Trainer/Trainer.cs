

namespace _11.Pokemon_Trainer
{
    using System.Collections.Generic;
    public class Trainer
    {
        private string name;
        private int numberOfBadges;
        private List<Pokemon> list;

        public Trainer(string name)
        {
            this.name = name;
            this.numberOfBadges = 0;
            this.list = new List<Pokemon>();
        }

        public List<Pokemon> Pokemons
        {
            get { return list; }
            set { list = value; }
        }

        public int NumberOfBadges
        {
            get { return numberOfBadges; }
            set { numberOfBadges = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
