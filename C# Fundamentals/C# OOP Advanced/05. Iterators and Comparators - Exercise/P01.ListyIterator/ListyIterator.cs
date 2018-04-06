namespace P01.ListyIterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListyIterator<T>
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
            if (!collection.Any())
            {
                throw new ArgumentException("Invalid Operation");
            }
            Console.WriteLine(collection[currentIndex]);
        }
       
    }
}
