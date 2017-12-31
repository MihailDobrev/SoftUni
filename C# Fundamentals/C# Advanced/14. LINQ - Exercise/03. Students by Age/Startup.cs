namespace _03.Students_by_Age
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
                .Where(x => int.Parse(x[2])>=18 && int.Parse(x[2])<=24)
                .ToList()
                .ForEach(x => Console.WriteLine(x[0] + " " + x[1]+ " " + x[2]));
        }
    }
}
