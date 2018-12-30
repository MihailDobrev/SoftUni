using System;
using System.Linq;

public class ArrayStack<T>
{
    private const int InitialCapcity = 16;
    private T[] elements;
    public int Count { get; private set; }

    public ArrayStack(int capacity = InitialCapcity)
    {
        this.elements = new T[capacity];
    }

    public void Push(T element)
    {
        if (this.Count == this.elements.Length)
        {
            this.Grow();
        }

        this.elements[this.Count] = element;
        this.Count++;
    }

    private void Grow()
    {
        var newElements = new T[2 * this.Count];
        this.CopyAllElements(newElements);
        this.elements = newElements;
    }

    private void CopyAllElements(T[] newArray)
    {
        for (int i = 0; i < this.Count; i++)
        {
            newArray[i] = this.elements[i];
        }
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        this.Count--;
        var result = this.elements[this.Count];
        this.elements[this.Count] = default(T);
        return result;
    }

    public T[] ToArray() => this.elements.Take(this.Count).Reverse().ToArray();
    
}
