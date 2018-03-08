namespace _09.CollectionHierarchy
{
    using System.Collections.Generic;
    public interface IAddible
    {
        List<string> Collection { get; }
        int Add(string input);
    }
}
