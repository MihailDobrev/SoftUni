namespace P03.Stack
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Stack<T> : IEnumerable<T>
    {
        private List<T> stack;

        public void Push(T element)
        {
            stack.Add(element);
        }
        public Stack()
        {
            stack = new List<T>();
        }

        public T Pop()
        {
            if (!stack.Any())
            {
                throw new System.ArgumentException("No elements");
            }
            var lastElement= stack[stack.Count - 1];
            stack.RemoveAt(stack.Count-1);
            return lastElement;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
