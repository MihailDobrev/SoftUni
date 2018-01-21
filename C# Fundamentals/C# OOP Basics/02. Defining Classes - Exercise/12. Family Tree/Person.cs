using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Family_Tree
{
    public class Person
    {
        public Person(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
            Parents = new List<Parent>();
            Children = new List<Child>();
        }

        public string Name { get; set; }
        public string Birthday { get; set; }

        private List<Parent> parents;

        public List<Parent> Parents
        {
            get { return parents; }
            set { parents = value; }
        }

        private List<Child> children;

        public List<Child> Children
        {
            get { return children; }
            set { children = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.Name} {this.Birthday}{Environment.NewLine}");
            sb.Append($"Parents:{Environment.NewLine}");
            var parents = this.Parents.Select(p => $"{p.Name} {p.Birthday}");
            sb.Append(string.Join(Environment.NewLine, parents));
            sb.Append(Environment.NewLine);
            sb.Append($"Children:{Environment.NewLine}");
            var children = this.Children.Select(c => $"{c.Name} {c.Birthday}");
            sb.Append(string.Join(Environment.NewLine,children));

            return sb.ToString();
        }
    }
}
