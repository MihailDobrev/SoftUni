namespace P07.Equality_Logic
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);

            }
            return result;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Person person = (Person)obj;
                return (this.Name == person.Name) && (this.Age == person.Age);
            }
        }

        public override int GetHashCode()
        {
            return string.Format("{0}{1}", Name, Age).GetHashCode();
        }
    }
}
