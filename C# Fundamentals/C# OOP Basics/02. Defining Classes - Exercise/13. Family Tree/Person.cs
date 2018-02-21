namespace _13.Family_Tree
{
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        public Person(string fullName, string birthDate)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Parents = new Dictionary<string, string>();
            Children = new Dictionary<string, string>();
        }

        public string FullName { get; set; }

        public string BirthDate { get; set; }

        public Dictionary<string, string> Parents { get; set; }

        public Dictionary<string, string> Children { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{FullName} {BirthDate}");
            sb.AppendLine("Parents:");
            foreach (var pair in Parents)
            {
                sb.AppendLine($"{pair.Key} {pair.Value}");
            }
            sb.AppendLine("Children:");
            foreach (var pair in Children)
            {
                sb.AppendLine($"{pair.Key} {pair.Value}");
            }
            return sb.ToString();
        }
    }
}
