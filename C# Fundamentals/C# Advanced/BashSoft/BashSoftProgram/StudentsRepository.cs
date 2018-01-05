namespace BashSoftProgram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void InitializeData()
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData();
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitializedExeption);
            }
        }

        private static void ReadData()
        {
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                string[] tokens = input.Split(' ');
                string course = tokens[0];
                string student = tokens[1];
                int mark = int.Parse(tokens[2]);

                if (!studentsByCourse.ContainsKey(course))
                {
                    studentsByCourse.Add(course, new Dictionary<string, List<int>>());
                }
                if (!studentsByCourse[course].ContainsKey(student))
                {
                    studentsByCourse[course].Add(student, new List<int>());
                }
                studentsByCourse[course][student].Add(mark);

                input = Console.ReadLine();
            }
            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }

        private static bool IsQuerryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }
            
            if (studentsByCourse.ContainsKey(courseName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }
            return false;
        }

        private static bool IsQuerryForStudentsPossible(string courseName,string studentUserName)
        {
            if (studentsByCourse.ContainsKey(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }
            return false;
        }      

        public static void GetStudentScoresFromCourse(string courseName, string userName)
        {
            if (IsQuerryForStudentsPossible(courseName,userName))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(userName, studentsByCourse[courseName][userName]));
            }
        }

        public static void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQuerryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}");

                foreach (var studentsMarksEntry in studentsByCourse[courseName])
                {
                    OutputWriter.PrintStudent(studentsMarksEntry);
                }
            }
        }
    }   
}
