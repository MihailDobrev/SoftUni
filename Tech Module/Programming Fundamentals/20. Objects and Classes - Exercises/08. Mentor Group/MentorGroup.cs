namespace _8.Mentor_group
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;

    public class MentorGroup
    {
        const string Format = "dd/MM/yyyy";
        static void Main()
        {

            Dictionary<string, Student> studentsGroup = AddStudentsInGroup();

            AddComments(studentsGroup);

            PrintResults(studentsGroup);

        }

        private static void PrintResults(Dictionary<string, Student> studentsGroup)
        {
            foreach (var student in studentsGroup.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);
                Console.WriteLine("Comments:");
                if (student.Value.Comments.Count > 0)
                {
                    Console.WriteLine($"- {string.Join("\n- ", student.Value.Comments)}");
                }
                Console.WriteLine("Dates attended:");
                if (student.Value.Dates.Count > 0)
                {
                    foreach (var date in student.Value.Dates.OrderBy(x => x.Date))
                    {
                        Console.WriteLine($"-- {date:dd/MM/yyyy}");
                    }
                }
            }
        }

        private static void AddComments(Dictionary<string, Student> studentsGroup)
        {
            string inputLine2 = Console.ReadLine();

            while (!inputLine2.Equals("end of comments"))
            {
                string[] inputArr = inputLine2.Split('-');
                string commenter = inputArr[0];
                if (!studentsGroup.ContainsKey(commenter))
                {
                    inputLine2 = Console.ReadLine();
                    continue;
                }
                else
                {
                    List<string> comments = new List<string>();
                    comments.Add(inputArr[1]);
                    studentsGroup[commenter].Comments.AddRange(comments);
                }

                inputLine2 = Console.ReadLine();
            }
        }

        private static Dictionary<string, Student> AddStudentsInGroup()
        {
            Dictionary<string, Student> studentsGroup = new Dictionary<string, Student>();
            string inputLine1 = Console.ReadLine();

            while (!inputLine1.Equals("end of dates"))
            {

                string[] inputToArr = inputLine1.Split(' ');

                string name = inputToArr[0];

                if (!studentsGroup.ContainsKey(name))
                {
                    studentsGroup.Add(name, new Student());
                    studentsGroup[name].Dates = new List<DateTime>();
                    studentsGroup[name].Comments = new List<string>();
                    studentsGroup[name].Name = name;
                }

                if (inputToArr.Length < 2)
                {
                    inputLine1 = Console.ReadLine();
                    continue;
                }
                else
                {
                    List<DateTime> dates =
                        inputToArr[1].Split(',')
                            .Select(x => DateTime.ParseExact(x, Format, CultureInfo.InvariantCulture))
                            .ToList();
                    studentsGroup[name].Dates.AddRange(dates);
                }

                inputLine1 = Console.ReadLine();
            }

            return studentsGroup;

        }
    }
}
