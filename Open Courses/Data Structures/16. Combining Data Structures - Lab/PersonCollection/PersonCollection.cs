using System.Collections.Generic;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> personsByEmail = new Dictionary<string, Person>();
    private Dictionary<string, SortedSet<Person>> personByEmailDomain = new Dictionary<string, SortedSet<Person>>();
    private Dictionary<string, SortedSet<Person>> personByNameAndTown = new Dictionary<string, SortedSet<Person>>();
    private OrderedDictionary<int, SortedSet<Person>> personsByAge = new OrderedDictionary<int, SortedSet<Person>>();
    private Dictionary<string, OrderedDictionary< int, SortedSet<Person>>> personsByTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.FindPerson(email) != null)
        {
            return false;
        }
        var person = new Person
        {
            Name = name,
            Age = age,
            Email = email,
            Town = town
        };
        personsByEmail.Add(email, person);

        string emailDomain = this.ExtractEmailDomain(email);
        this.personByEmailDomain.AppendValueToKey(emailDomain, person);

        string nameAndTown = this.CombineNameAndTown(name, town);
        this.personByNameAndTown.AppendValueToKey(nameAndTown, person);

        this.personsByAge.AppendValueToKey(age, person);

        this.personsByTownAndAge.EnsureKeyExists(town);
        this.personsByTownAndAge[town].AppendValueToKey(age, person);

        return true;
    }

    private string ExtractEmailDomain(string email)
    {
       var domain=email.Split('@')[1];
       return domain;
    }

    public int Count
    {
        get
        {
            return this.personsByEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        Person person;
        var personExists = this.personsByEmail.TryGetValue(email, out person);
        return person;
    }

    public bool DeletePerson(string email)
    {
        var person = this.FindPerson(email);

        if (person==null)
        {
            return false;
        }

        var personDeleted = this.personsByEmail.Remove(email);

        string emailDomain = this.ExtractEmailDomain(email);
        this.personByEmailDomain[emailDomain].Remove(person);

        string nameAndTown = this.CombineNameAndTown(person.Name, person.Town);
        this.personByNameAndTown[nameAndTown].Remove(person);

        this.personsByAge[person.Age].Remove(person);

        this.personsByTownAndAge[person.Town][person.Age].Remove(person);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        return this.personByEmailDomain.GetValuesForKey(emailDomain);
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var nameAndTown = this.CombineNameAndTown(name, town);
        return this.personByNameAndTown.GetValuesForKey(nameAndTown);
    }

    private string CombineNameAndTown(string name, string town)
    {
        const string seperator = "|!|";
        return name + seperator + town;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var personsInRange =
            this.personsByAge.Range(startAge, true, endAge, true);

        foreach (var personsByAge in personsInRange)
        {
            foreach (var person in personsByAge.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!this.personsByTownAndAge.ContainsKey(town))
        {
            yield break;
        }
        var personsInRange =
            this.personsByTownAndAge[town].Range(startAge, true, endAge, true);

        foreach (var personsByTownAndAge in personsInRange)
        {
            foreach (var person in personsByTownAndAge.Value)
            {
                yield return person;
            }
        }
    }
}
