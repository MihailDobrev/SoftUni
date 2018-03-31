namespace P08.Custom_List_Sorter
{
    using System;

    public static class Sorter
    {
        public static void Sort<T>(CustomList<T> list)
            where T : IComparable
        {
            list.Sort();
        }
    }
}
