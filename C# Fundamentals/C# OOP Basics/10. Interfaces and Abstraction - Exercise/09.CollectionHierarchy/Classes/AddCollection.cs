namespace _09.CollectionHierarchy
{
    using System.Collections.Generic;
    public class AddCollection:IAddible
    {
        public AddCollection()
        {
            Collection = new List<string>();
        }

        public List<string> Collection { get; set; }

        public int Add(string input)
        {
            int indexToAdd = 0;
            if (Collection.Count>0)
            {
                indexToAdd = Collection.Count;
            }         
            Collection.Insert(indexToAdd,input);
            return indexToAdd;
        }
    }
}
