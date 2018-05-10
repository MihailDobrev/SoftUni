namespace P03.IteratorTest
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ListIterator : IEnumerable
    {
        private int internalIndex;
        public List<string> Collection { get; private set; }

        public ListIterator(string[] elements)
        {
            Collection = new List<string>();
            if (elements == null)
            {
                throw new ArgumentNullException();
            }
            Collection.AddRange(elements);
            internalIndex = 0;
        }
        public bool Move()
        {
            if (internalIndex + 1 < Collection.Count)
            {
                this.internalIndex++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (internalIndex + 1 < Collection.Count)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (!Collection.Any())
            {
                throw new Exception("Invalid Operation!");
            }
            string element = Collection[this.internalIndex];
            Console.WriteLine(element);
        }

        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < Collection.Count; index++)
            {
                yield return this.Collection[index];
            }
        }
    }
}
