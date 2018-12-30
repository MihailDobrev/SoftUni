using System;

public class LinkedQueue<T>
{
    private class QueueNode<T>
    {
        public T Value { get; set; }

        public QueueNode<T> NextNode { get; set; }

        public QueueNode<T> PrevNode { get; set; }

        public QueueNode(T value)
        {
            this.Value = value;
        }
    }

    private QueueNode<T> head;
    private QueueNode<T> tail;
    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new QueueNode<T>(element);
        }
        else
        {
            QueueNode<T> newHead = new QueueNode<T>(element);
            newHead.NextNode = this.head;

            this.head.PrevNode = newHead;
            this.head = newHead;
        }
        this.Count++;

    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        var lastElement = this.tail.Value;

        this.tail = this.tail.PrevNode;
        if (this.tail != null)
        {
            this.tail.NextNode = null;
        }
        else
        {
            this.head = null;
        }
        this.Count--;

        return lastElement;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];

        var currentNode = this.tail;

        for (int index = 0; index < this.Count; index++)
        {
            array[index] = currentNode.Value;
            currentNode = currentNode.PrevNode;
        }

        return array;
    }
}
