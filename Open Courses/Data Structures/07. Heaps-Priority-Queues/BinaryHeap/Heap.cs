using System;
public static class Heap<T> where T : IComparable<T>
{
    public static void Sort(T[] arr)
    {
        for (int i = arr.Length / 2; i >= 0; i--)
        {
            HeapifyDown(arr, 1, arr.Length);
        }
        for (int i = arr.Length - 1; i > 0; i--)
        {
            Swap(arr, 0, i);
            HeapifyDown(arr, 0, i);
        }
    }

    private static void HeapifyDown(T[] arr, int index, int length)
    {
        while (index < length / 2)
        {
            int child = 2 * index + 1;

            if (child + 1 < length && IsGreater(arr, child + 1, child))
            {
                child++;
            }

            if (IsGreater(arr, index, child))
            {
                break;
            }

            Swap(arr, child, index);

            index = child;
        }
    }

    private static void Swap(T[] arr, int a, int b)
    {
        T temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }

    private static bool IsGreater(T[] arr, int a, int b)
    {
        return arr[a].CompareTo(arr[b]) > 0;
    }
}
