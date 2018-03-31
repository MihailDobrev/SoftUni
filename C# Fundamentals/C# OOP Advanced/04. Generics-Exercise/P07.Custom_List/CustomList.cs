namespace P07.Custom_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomList<T>
        where T:IComparable<T>
    {
       
        public List<T> Data { get; }

        public CustomList()
        {
            Data = new List<T>();
        }

        public void Add(T element)
        {
            this.Data.Add(element);
        }

        public T Remove(int index)
        {
            var elementToRemove = Data[index];
            this.Data.RemoveAt(index);
            return elementToRemove;
        }

        public bool Contains(T element) => Data.Contains(element);

        public void Swap(int index1, int index2)
        {
            var firstPosition = Data[index1];
            Data[index1] = Data[index2];
            Data[index2] = firstPosition;
        }

        public int CountGreaterThan(T element)
        {
            int greaterElementsCount = 0;

            foreach (var item in Data)
            {
                if (element.CompareTo(item) < 0)
                {
                    greaterElementsCount++;
                }
            }

            return greaterElementsCount;
        }

        public T Max() => Data.Max();

        public T Min() => Data.Min();

      
    }
}
