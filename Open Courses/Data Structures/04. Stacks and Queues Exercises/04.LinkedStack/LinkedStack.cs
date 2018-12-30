using System;
using System.Linq;

public class LinkedStack<T>
{
    private Node<T> firstNode;
    public int Count { get; private set; }

    public void Push(T element)
    {
        Node<T> node = new Node<T>(element, this.firstNode);

        this.firstNode = node;

        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The stack is empty;");
        }

        var currentFirstValue = this.firstNode.GetValue;

        this.firstNode = this.firstNode.NextNode;
        this.Count--;
        return currentFirstValue;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        var node = this.firstNode;

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = node.GetValue;
            node = node.NextNode;
        }

        return array.ToArray();
    }

    private class Node<T>
    {
        private T value;
        public Node<T> NextNode { get; set; }

        public Node(T value, Node<T> nextNode = null)
        {
            this.value = value;

            this.NextNode = nextNode;
        }

        public T GetValue => this.value;
    }
}
