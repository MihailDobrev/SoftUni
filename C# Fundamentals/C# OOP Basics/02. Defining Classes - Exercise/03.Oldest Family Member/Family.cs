namespace _03.Oldest_Family_Member
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        List<Person> people = new List<Person>();

        public void AddMember(Person person)
        {
            this.people.Add(person);
        }

        public Person GetOldestMember()
        {
            return this.people.OrderByDescending(x => x.age).FirstOrDefault();
        }
    }
}
