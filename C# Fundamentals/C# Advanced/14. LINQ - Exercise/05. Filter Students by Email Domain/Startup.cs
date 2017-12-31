namespace _05.Filter_Students_by_Email_Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<string[]> students = new List<string[]>();

            while (input != "END")
            {
                string[] inputArgs = input.Split();

                students.Add(inputArgs);
                input = Console.ReadLine();
            }
            students
                .Where(x => x[2].Contains("@gmail.com"))
                .ToList()
                .ForEach(x => Console.WriteLine(x[0]+" "+ x[1]));
        }
    }
}
