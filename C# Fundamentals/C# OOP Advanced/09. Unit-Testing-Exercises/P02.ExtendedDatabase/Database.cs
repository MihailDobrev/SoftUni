namespace P02.ExtendedDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database
    {
        public List<Person> People { get; private set; }

        public Database()
        {
            People = new List<Person>();
        }

        public void Add(Person person)
        {
            if (this.People.Any(p => p.Id == person.Id) ||
                this.People.Any(p => p.UserName == person.UserName))
            {
                throw new InvalidOperationException();
            }
            else
            {
                People.Add(person);
            }
        }

        public void Remove(string username)
        {
            var personToRemove = People.FirstOrDefault(p => p.UserName == username);
            RemovePerson(personToRemove);
        }

        private void RemovePerson(Person personToRemove)
        {
            if (personToRemove == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                People.Remove(personToRemove);
            }
        }

        public void Remove(long id)
        {
            var personToRemove = People.FirstOrDefault(p => p.Id == id);
            RemovePerson(personToRemove);
        }
        public Person FindByUsername(string username)
        {
            if (username==null)
            {
                throw new ArgumentException();
            }
            var searchedPerson = People.FirstOrDefault(p => p.UserName == username);
            if (searchedPerson==null)
            {
                throw new InvalidOperationException();
            }
            return searchedPerson;
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var searchedPerson = People.FirstOrDefault(p => p.Id == id);
            if (searchedPerson == null)
            {
                throw new InvalidOperationException();
            }
            return searchedPerson;
        }


    }
}
