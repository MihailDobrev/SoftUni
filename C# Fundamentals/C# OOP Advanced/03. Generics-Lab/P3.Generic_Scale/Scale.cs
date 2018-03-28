using System;

public class Scale<T>
    where T : IComparable<T>
{
    public T Left { get; }
    public T Right { get; }
    public Scale(T left, T right)
    {
        Left = left;
        Right = right;
    }

    public T GetHeavier()
    {
        if (Left.CompareTo(Right) > 0)
        {
            return Left;
        }
        else if (Left.CompareTo(Right) < 0)
        {
            return Right;
        }
        return default(T);
    }
}