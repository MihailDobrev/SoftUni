namespace _07.Valid_Usernames
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    public class Startup
    {
        public static void Main()
        {
            string userNameInput = Console.ReadLine();
            string pattern = @"\b[A-Za-z][A-Za-z0-9_]{2,24}\b";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(userNameInput);
            List<string> userNames = new List<string>();

            string currentUserName = string.Empty;

            foreach (Match match in matches)
            {
                currentUserName = match.Value;
                userNames.Add(currentUserName);
            }

            Queue<string> topUserNames = new Queue<string>();

            int currentTopSumOfUsernames = 0;

            for (int index = 1; index < userNames.Count; index++)
            {
                currentUserName = userNames[index];
                int sumOfCurrentAndPreviousUsername = userNames[index].Length + userNames[index - 1].Length;

                if (sumOfCurrentAndPreviousUsername > currentTopSumOfUsernames)
                {
                    topUserNames.Clear();
                    topUserNames.Enqueue(userNames[index - 1]);
                    topUserNames.Enqueue(userNames[index]);
                    currentTopSumOfUsernames = sumOfCurrentAndPreviousUsername;
                }
            }

            while(topUserNames.Count>0)
            { 
                string name=topUserNames.Dequeue();
                Console.WriteLine(name);
            }
        }
    }
}
