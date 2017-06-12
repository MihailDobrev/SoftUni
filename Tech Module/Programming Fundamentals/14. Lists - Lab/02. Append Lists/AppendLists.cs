
namespace _2.Append_Lists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AppendLists
    {
        static void Main()
        {
                       
            var lists = Console.ReadLine().Split('|');
            var results = new List<int>();


            for (int i = lists.Length-1; i >=0 ; i--)
            {
                int[] numbers = lists[i].Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                results.AddRange(numbers);
            }

            Console.WriteLine(string.Join(" ", results));
        }
    }
}
