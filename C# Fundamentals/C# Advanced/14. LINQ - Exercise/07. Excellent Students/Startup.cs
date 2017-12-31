namespace _07.Excellent_Students
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
                .Where(x => x.Any(y => y == "6"))
                .ToList()
                .ForEach(x => Console.WriteLine(x[0] + " " + x[1]));
        }
    }
}
