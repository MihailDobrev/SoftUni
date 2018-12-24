namespace _02.SortWords
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var words = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .OrderBy(a=>a);

            Console.WriteLine(string.Join(" ", words));
        }
    }
}
