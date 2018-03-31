namespace P08.Custom_List_Sorter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class CustomList<T>:List<T>
        where T : IComparable
    {      

        public T Remove(int index)
        {
            var elementToRemove = this[index];
            this.RemoveAt(index);
            return elementToRemove;
        }     

        public void Swap(int index1, int index2)
        {
            var firstPosition = this[index1];
            this[index1] = this[index2];
            this[index2] = firstPosition;
        }

        public int CountGreaterThan(T element)
        {
            int greaterElementsCount = 0;

            foreach (var item in this)
            {
                if (element.CompareTo(item) < 0)
                {
                    greaterElementsCount++;
                }
            }

            return greaterElementsCount;
        }

        public T Max() => this.Max(e => e);
        
        public T Min() => this.Min(e => e);

  
    }
}
