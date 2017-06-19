
namespace _4.Average_Grades
{
    using System;
    using System.Linq;

    public class AverageGrades
    {
        static void Main()
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            Student[] students = new Student[numberOfStudents];
            
            for (int i = 0; i < numberOfStudents; i++)
            {
                Student student = ReadStudent(Console.ReadLine());
                students[i] = new Student() { Name = student.Name, Grades = student.Grades };

            }
            var topStudentsNames = students
                 .Where(x => x.AverageGrade >= 5)
                 .Select(x => x.Name).Distinct()
                 .OrderBy(x => x)
                 .ToArray();

            foreach (var topStudent in topStudentsNames)
            {

                var studentAverageGrades = students
                    .Where(x => x.Name == topStudent && x.AverageGrade >= 5)
                    .Select(x => x.AverageGrade)
                    .OrderByDescending(x => x)
                    .ToArray();
                foreach (var averageGrade in studentAverageGrades)
                {
                    Console.WriteLine($"{topStudent} -> {averageGrade:F2}");
                }
                
            }
        }

        public static Student ReadStudent(string input)
        {
            var properties = input.Split(' ').Select(x => x).ToList();
            var name = properties[0];
            properties.Remove(properties[0]);
            var grades = properties.Select(double.Parse).ToList();
            Student student = new Student() { Name = name, Grades = grades };
            return student;
        }
    }
}
