namespace P06.Strategy_Pattern
{
    using System.Collections.Generic;

    public class AgeSorter : IComparer<Person>
    {
        
        public int Compare(Person first, Person second)
        {
            return first.Age.CompareTo(second.Age);
        }
    }
}
