
using System.Collections.Generic;

    public class StackOfStrings
    {
        private List<string> list;
        public List<string> Data
        {
            get { return list; }
            set { list = value; }
        }

        public void Push(string item)
        {
            this.list.Add(item);
        }

        public string Pop()
        {
            string last = list[this.list.Capacity - 1];
            this.list.RemoveAt(this.list.Capacity - 1);
            return last;
        }

        public string Peek()
        {
            return this.list[this.list.Capacity - 1];
        }

        public bool IsEmpty()
        {
            return this.list.Capacity == 0 ? true : false;
        }
    }
