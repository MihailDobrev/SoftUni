namespace Animals
{
    using System;
    using System.Text;

    public abstract class Animal
    {
        public const string errorMessage = "Invalid input!";
        private string name;
        private int age;
        private string gender;

        public Animal(string gender, int age, string name)
        {
            Gender = gender;
            Age = age;
            Name = name;
        }

        public string Gender
        {
            get { return gender; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(errorMessage);
                }
                gender = value;
            }
        }

        public int Age
        {
            get { return age; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(errorMessage);
                }
                age = value;
            }
        }

        public string Name
        {
            get { return name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(errorMessage);
                }
                name = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{this.name} {this.age} {this.gender}");
            sb.Append($"{this.ProduceSound()}");
            return sb.ToString();
        }
    }
}
