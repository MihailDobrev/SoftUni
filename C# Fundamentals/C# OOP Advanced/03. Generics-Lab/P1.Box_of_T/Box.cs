using System.Collections.Generic;
using System.Linq;

public class Box<T>
{

    public List<T> Data { get; }

    public int Count => Data.Count;

    public Box()
    {
        Data = new List<T>();
    }

    public void Add(T element)
    {
        Data.Add(element);
    }

    public T Remove()
    {
        var lastElement = Data.Last();
        Data.RemoveAt(Data.Count - 1);
        return lastElement;
    }
}

