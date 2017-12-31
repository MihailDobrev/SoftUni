namespace _09.Students_Enrolled_in_2014_or_2015
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<List<string>> students = new List<List<string>>();

            while (input != "END")
            {
                List<string> inputArgs = input.Split().ToList();

                students.Add(inputArgs);
                input = Console.ReadLine();
            }
            students
                .Where(x => x[0].EndsWith("14") || x[0].EndsWith("15"))
                .ToList()
                .ForEach(x => Console.WriteLine(string.Format("{0}",
                string.Join(" ", x.Skip(1).ToList()))));
        }
    }
}
