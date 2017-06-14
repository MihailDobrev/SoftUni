namespace _5.Short_Words_Sorted
{
    using System;
    using System.Linq;
    public class ShortWordsSorted
    {
        static void Main()
        {
            char[] delimiters = { '.', ',', ':', ';', '(', ')', '[', ']', '\"', '\'', '\\', '/', '!', '?', ' ' };
            var words = Console.ReadLine()
                    .ToLower()
                    .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                    .Where(n => n.Length < 5)
                    .Distinct()
                    .OrderBy(x=>x)
                    .ToArray();
            Console.WriteLine(string.Join(", ",words));        
        }
    }
}
