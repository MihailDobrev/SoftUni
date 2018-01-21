namespace _12.Google
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Person
    {
        private Company company;
        private Car car;
        private List<Parent> parents;
        private List<Child> children;
        private List<Pokemon> pokemons;

        public Person()
        {
            this.company = new Company();
            this.car = new Car();
            this.parents = new List<Parent>();
            this.children = new List<Child>();
            this.pokemons = new List<Pokemon>();
        }


        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }


        public List<Child> Children
        {
            get { return children; }
            set { children = value; }
        }


        public List<Parent> Parents
        {
            get { return parents; }
            set { parents = value; }
        }

        public Car Car
        {
            get { return car; }
            set { car = value; }
        }

        public Company Company
        {
            get { return company; }
            set { company = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Company:{Environment.NewLine}");
            if (this.company.Name != null)
            {
                sb.Append($"{this.company.Name} {this.company.Department} {this.company.Salary:F2}{Environment.NewLine}");
            }
            sb.Append($"Car:{Environment.NewLine}");
            if (this.car.Model != null)
            {
                sb.Append($"{this.car.Model} {this.car.Speed}{Environment.NewLine}");
            }

            sb.Append($"Pokemon:{Environment.NewLine}");
            if (this.pokemons.Count > 0)
            {
                List<string> pokemonsInText = this.pokemons.Select(p => $"{p.Name} {p.Type}").ToList();
                sb.Append(string.Join(Environment.NewLine, pokemonsInText));
                sb.Append(Environment.NewLine);
            }

            sb.Append($"Parents:{Environment.NewLine}");
            if (this.parents.Count > 0)
            {
                List<string> parentsInText = this.parents.Select(p => $"{p.Name} {p.Birthday}").ToList();
                sb.Append(string.Join(Environment.NewLine, parentsInText));
                sb.Append(Environment.NewLine);
            }
            sb.Append($"Children:{Environment.NewLine}");
            if (this.children.Count > 0)
            {
                List<string> childrenInText = this.Children.Select(p => $"{p.Name} {p.Birthday}").ToList();
                sb.Append(string.Join(Environment.NewLine, childrenInText));
            }

            return sb.ToString();
        }
    }
}
