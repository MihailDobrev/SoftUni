using System;
using System.Collections;
using System.Collections.Generic;

public class ReversedList<T> : IEnumerable<T>
{
    private const int INITIAL_SIZE = 2;

    private T[] contents;

    public int Capacity => this.contents.Length;
    public int Count { get; private set; }

    public ReversedList()
    {
        this.contents = new T[INITIAL_SIZE];
    }

    public T this[int index]
    {
        get
        {
            Validate(index);

            return this.contents[GetReversedIndex(index)];
        }

        set
        {
            Validate(index);

            this.contents[GetReversedIndex(index)] = value;
        }
    }

    private void Validate(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public void Add(T item)
    {
        if (this.Count + 1 > this.contents.Length)
        {
            ExtendTwice();
        }

        this.contents[this.Count++] = item;
    }

    private void ExtendTwice()
    {
        T[] copy = new T[this.contents.Length * 2];

        for (int index = 0; index < this.contents.Length; index++)
        {
            copy[index] = this.contents[index];
        }

        this.contents = copy;
    }


    public T RemoveAt(int index)
    {
        Validate(index);

        var reversedIndex = GetReversedIndex(index);
        var removedElement = this.contents[reversedIndex];

        this.contents[reversedIndex] = default(T);
        this.Shift(reversedIndex);
        this.Count--;

        if (this.Count <= this.contents.Length / 4)
        {
            this.Shrink();
        }
        return removedElement;
    }

    private void Shrink()
    {
        T[] copy = new T[this.contents.Length / 2];

        for (int i = 0; i < this.Count; i++)
        {
            copy[i] = this.contents[i];
        }

        this.contents = copy;
    }


    private void Shift(int index)
    {
        for (int i = index; i < this.Count; i++)
        {
            this.contents[i] = this.contents[i + 1];
        }
    }

    private int GetReversedIndex(int index)
        => this.Count - 1 - index;

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = Count - 1; i >= 0; i--)
        {
            yield return contents[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

