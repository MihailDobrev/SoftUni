namespace _08.WeakStudents
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
                .Where(x => x.Skip(2).Count(y => int.Parse(y) <= 3) >= 2)
                .ToList()
                .ForEach(x => Console.WriteLine(x[0] + " " + x[1]));
        }    
    }
}
