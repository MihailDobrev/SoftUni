namespace _09.CollectionHierarchy.Classes
{
    using _09.CollectionHierarchy.Interfaces;
    using System.Collections.Generic;
    public class MyList : IUsed
    {
        private int used;

        public MyList()
        {
            Collection = new List<string>();
        }

        public List<string> Collection { get; set; }
        public int Used
        {
            get { return used; }
            set { used = Collection.Count; }
        }

        public int Add(string input)
        {
            Collection.Insert(0, input);
            return 0;
        }

        public string Remove()
        {
            string lastElement = Collection[0];
            Collection.RemoveAt(0);
            return lastElement;
        }
    }
}
