using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T> where T : IComparable<T>
{
    private LinkedList<T> byInsertion;
    private OrderedBag<LinkedListNode<T>> byAscending;
    private OrderedBag<LinkedListNode<T>> byDescending;
    
    public FirstLastList()
    {
        this.byInsertion = new LinkedList<T>();
        this.byAscending = new OrderedBag<LinkedListNode<T>>((x, y) => x.Value.CompareTo(y.Value));
        this.byDescending = new OrderedBag<LinkedListNode<T>>((x, y) => y.Value.CompareTo(x.Value));
    }

    public int Count
    {
        get => byInsertion.Count;
    }

    public void Add(T element)
    {
        LinkedListNode<T> node = new LinkedListNode<T>(element);
        this.byInsertion.AddLast(node);
        this.byAscending.Add(node);
        this.byDescending.Add(node);
    }

    public void Clear()
    {
        this.byInsertion.Clear();
        this.byAscending.Clear();
        this.byDescending.Clear();
    }

    public IEnumerable<T> First(int count)
    {
        if (!CountIsInBounds(count))
        {
            throw new ArgumentOutOfRangeException();
        }

        LinkedListNode<T> current = this.byInsertion.First;

        int start = 0;

        while (start < count)
        {
            yield return current.Value;
            current = current.Next;
            start++;
        }
    }

    private bool CountIsInBounds(int count)
    {
        return count >= 0 && count <= this.Count;
    }

    public IEnumerable<T> Last(int count)
    {
        if (!CountIsInBounds(count))
        {
            throw new ArgumentOutOfRangeException();
        }

        LinkedListNode<T> current = this.byInsertion.Last;

        int start = 0;

        while (start < count)
        {
            yield return current.Value;
            current = current.Previous;
            start++;
        }
    }

    public IEnumerable<T> Max(int count)
    {
        if (!CountIsInBounds(count))
        {
            throw new ArgumentOutOfRangeException();
        }

        var maxElements = byDescending.Take(count);

        foreach (var item in maxElements)
        {
            yield return item.Value;
        }
    }

    public IEnumerable<T> Min(int count)
    {
        if (!CountIsInBounds(count))
        {
            throw new ArgumentOutOfRangeException();
        }

        var minElements = byAscending.Take(count);

        foreach (var item in minElements)
        {
            yield return item.Value;
        }
    }

    public int RemoveAll(T element)
    {
        LinkedListNode<T> node = new LinkedListNode<T>(element);

        foreach (var item in this.byAscending.Range(node, true, node, true))
        {
            this.byInsertion.Remove(item);
        }

        int count = this.byAscending.RemoveAllCopies(node);
        this.byDescending.RemoveAllCopies(node);

        return count;
    }
}
