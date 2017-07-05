namespace _06.Valid_Usernames
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    public class ValidUsernames
    {
        static void Main()
        {
            string line = Console.ReadLine();
            string splitter = @"\W+";
            string[] usernames = Regex.Replace(line, splitter, " ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"^[a-zA-Z][a-zA-Z0-9_]{2,24}$";
            Regex regex = new Regex(pattern);
            List<string> valid = new List<string>();

            foreach (var item in usernames)
            {
                if (regex.IsMatch(item))
                {
                    valid.Add(item);
                }
            }

            int sumMax = 0;
            string first = String.Empty;
            string second = String.Empty;

            for (int i = 1; i < valid.Count; i++)
            {
                int currentSum = valid[i - 1].Length + valid[i].Length;
                if (currentSum > sumMax)
                {
                    sumMax = currentSum;
                    first = valid[i - 1];
                    second = valid[i];
                }
            }
            Console.WriteLine(first);
            Console.WriteLine(second);
        }
    }
}
