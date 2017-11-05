namespace _01.Unique_Usernames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int usernames = int.Parse(Console.ReadLine());
            HashSet<string> uniqueNames = new HashSet<string>();

            for (int i = 0; i < usernames; i++)
            {
                string username = Console.ReadLine();
                uniqueNames.Add(username);

            }

            uniqueNames.ToList().ForEach(name => Console.WriteLine(name));
        }
    }
}
