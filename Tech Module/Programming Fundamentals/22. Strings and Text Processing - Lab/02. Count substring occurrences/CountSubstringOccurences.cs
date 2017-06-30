namespace _02.Count_substring_occurrences
{
    using System;
    public class CountSubstringOccurences
    {
        static void Main()
        {
            string input = Console.ReadLine().ToLower();
            string searchedText = Console.ReadLine().ToLower();

            var index = input.IndexOf(searchedText);
            int counter = 0;

            while (index!=-1)
            {
                counter++;
                index = input.IndexOf(searchedText, index + 1);
                   
            }
            Console.WriteLine(counter);
        }
    }
}
