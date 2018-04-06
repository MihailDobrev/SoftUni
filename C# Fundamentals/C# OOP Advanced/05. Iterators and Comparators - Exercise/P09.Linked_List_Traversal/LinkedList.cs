namespace P09.Linked_List_Traversal
{
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        private List<T> collection;
        public int Count => collection.Count;

        public LinkedList()
        {
            collection = new List<T>();
        }
        public void Add(T element)
        {
            collection.Add(element);
        }

        public bool Remove(T element)
        {
            return collection.Remove(element);
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
