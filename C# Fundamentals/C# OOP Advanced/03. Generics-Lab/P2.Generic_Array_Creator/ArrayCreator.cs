
public static class ArrayCreator
{
    public static T[] Create<T>(int length, T item)
    {
        T[] array = new T[length];

        for (int index = 0; index < array.Length; index++)
        {
            array[index] = item;
        }

        return array;
    }
}
