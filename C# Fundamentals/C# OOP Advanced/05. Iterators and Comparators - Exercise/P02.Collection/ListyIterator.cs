namespace P02.Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ListyIterator<T>:IEnumerable<T>
    {
        private List<T> collection;
        private int currentIndex;

        public void Create(params T[] elements)
        {
            collection = new List<T>(elements);
        }
        public bool Move()
        {
            if (currentIndex + 1 < collection.Count)
            {
                currentIndex++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            if (currentIndex + 1 < collection.Count)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            CheckIfEmpty();
            Console.WriteLine(collection[currentIndex]);
        }

        private void CheckIfEmpty()
        {
            if (!collection.Any())
            {
                throw new ArgumentException("Invalid Operation");
            }
        }

        public string GetAllElements()
        {
            CheckIfEmpty();
            return string.Join(" ", this.collection);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int index = 0; index < collection.Count; index++)
            {
                yield return collection[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
