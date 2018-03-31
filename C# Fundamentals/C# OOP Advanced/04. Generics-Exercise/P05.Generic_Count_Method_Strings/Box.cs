using System;
using System.Collections.Generic;

namespace P05.Generic_Count_Method_Strings
{
    public class Box<T>
        where T : IComparable<T>
    {

        public int CountGreaterThan(List<T> contents, T element)
        {
            int greaterElementsCount = 0;

            foreach (var item in contents)
            {
                if (element.CompareTo(item) < 0)
                {
                    greaterElementsCount++;
                }
            }

            return greaterElementsCount;
        }
    }
}
