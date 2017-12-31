namespace _02.Students_by_First_and_Last_Name
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
                .Where(x => x[1].CompareTo(x[0]) > 0)
                .ToList()
                .ForEach(x => Console.WriteLine(x[0] + " " + x[1]));
        }
    }
}
