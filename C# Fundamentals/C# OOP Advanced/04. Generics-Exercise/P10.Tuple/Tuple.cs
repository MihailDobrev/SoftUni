using System;
using System.Collections.Generic;
using System.Text;

namespace P10.Tuple
{
    public class Tuple<T1,T2>
    {

        public Tuple(T1 firstItem, T2 secondItem)
        {
            this.item1 = firstItem;
            this.item2 = secondItem;
        }
        public T1 item1 { get; }

        public T2 item2 { get; }

        public override string ToString() => $"{item1.ToString()} -> {item2.ToString()}";
    }
}
