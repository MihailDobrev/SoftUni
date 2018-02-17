namespace _03._Student_System
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            ShowStudents();        
        }

        private static void ShowStudents()
        {
            List<Student> students = new List<Student>();
            string input;

            while ((input = Console.ReadLine()) != "Exit")
            {
                string[] commands = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string command = commands[0];

                if (command == "Create")
                {
                    Student student = new Student(commands[1], int.Parse(commands[2]), double.Parse(commands[3]));
                    students.Add(student);
                }
                else if (command == "Show")
                {
                    Student searchedStudent = students.Where(s => s.Name == commands[1]).FirstOrDefault();
                    if (searchedStudent!=null)
                    {
                        string commentary = string.Empty;
                        double mark = searchedStudent.Mark;

                        if (mark >= 5.00)
                        {
                            commentary = "Excellent student";
                        }
                        else if (mark < 5.00 && mark >= 3.50)
                        {
                            commentary = "Average student";
                        }
                        else
                        {
                            commentary = "Very nice person";
                        }
                        Console.WriteLine($"{searchedStudent.Name} is {searchedStudent.Age} years old. {commentary}.");
                    }
                   
                }
            }
        }
    }
}
