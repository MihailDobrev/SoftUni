namespace _09.CollectionHierarchy.Classes
{
    using System.Collections.Generic;
    public class AddRemoveCollection : IRemovable
    {
        public AddRemoveCollection()
        {
            Collection = new List<string>();
        }

        public List<string> Collection { get; set; }

        public int Add(string input)
        {
            Collection.Insert(0, input);
            return 0;
        }

        public string Remove()
        {
            int lastIndex = 0;
            if (Collection.Count > 0)
            {
                lastIndex = Collection.Count - 1;
            }

            string lastElement = Collection[lastIndex];
            Collection.RemoveAt(lastIndex);
            return lastElement;
        }
    }
}
