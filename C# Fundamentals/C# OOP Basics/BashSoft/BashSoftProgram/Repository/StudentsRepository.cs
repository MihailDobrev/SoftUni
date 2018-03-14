namespace BashSoftProgram
{
    using BashSoftProgram.Exceptions;
    using BashSoftProgram.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StudentsRepository
    {    
        private Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;
        private bool isDataInitialized;
        private RepositoryFilter filter;
        private RepositorySorter sorter;
        private Dictionary<string, Course> courses;
        private Dictionary<string, Student> students;


        public StudentsRepository(RepositoryFilter filter, RepositorySorter sorter)
        {          
            this.filter = filter;
            this.sorter = sorter;
            studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
        }

        public void LoadData(string fileName)
        {
            if (isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataAlreadyInitializedExeption);
            }

            students = new Dictionary<string, Student>();
            courses = new Dictionary<string, Course>();

            OutputWriter.WriteMessageOnNewLine("Reading data...");
            ReadData(fileName);

        }

        public void UnloadData()
        {
            if (!isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            students = null;
            courses = null;
            studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
            isDataInitialized = false;
        }

        private void ReadData(string fileName)
        {
            string path = SessionData.currentPath + "\\" + fileName;

            if (File.Exists(path))
            {
                string pattern = @"([A-Z][a-zA-Z#\+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";
                Regex rgx = new Regex(pattern);
                string[] allInputLines = File.ReadAllLines(path);

                for (int line = 0; line < allInputLines.Length; line++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                    {
                        Match currentMatch = rgx.Match(allInputLines[line]);
                        string courseName = currentMatch.Groups[1].Value;
                        string userName = currentMatch.Groups[2].Value;
                        string scoresStr = currentMatch.Groups[3].Value;

                        try
                        {
                            int[] scores = scoresStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                            if (scores.Any(s => s > 100 || s < 0))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                                continue;
                            }
                            if (scores.Length > Course.NumberOfTasksOnExam)
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                                continue;
                            }
                            if (!students.ContainsKey(userName))
                            {
                                students.Add(userName, new Student(userName));
                            }
                            if (!courses.ContainsKey(courseName))
                            {
                                courses.Add(courseName, new Course(courseName));
                            }

                            Course course = courses[courseName];
                            Student student = students[userName];

                            student.EnrollInCourse(course);
                            student.SetMarkOnCourse(courseName, scores);

                            course.EnrollStudent(student);
                        }
                        catch (FormatException fex)
                        {
                            throw new FormatException(fex.Message + $"at line: {line}");
                        }
                    }
                }

                isDataInitialized = true;
                OutputWriter.WriteMessageOnNewLine("Data read!");
            }
            else
            {
               throw new InvalidPathException();
            }    
        }

        private bool IsQuerryForCoursePossible(string courseName)
        {

            if (isDataInitialized)
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            if (courses.ContainsKey(courseName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }
            return false;
        }

        private bool IsQuerryForStudentPossible(string courseName, string studentUserName)
        {
            if (IsQuerryForCoursePossible(courseName) && courses[courseName].StudentsByName.ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }
            return false;
        }

        public void GetStudentScoresFromCourse(string courseName, string userName)
        {
            if (IsQuerryForStudentPossible(courseName, userName))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, double>(userName, courses[courseName].StudentsByName[userName].MarksByCourseName[courseName]));
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQuerryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}");

                foreach (var studentsMarksEntry in courses[courseName].StudentsByName)
                {
                    GetStudentScoresFromCourse(courseName, studentsMarksEntry.Key);
                }
            }
        }
        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (studentsToTake == null)
            {
                studentsToTake = courses[courseName].StudentsByName.Count;
            }
            Dictionary<string, double> marks =
                courses[courseName].StudentsByName.ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);
                filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {

            if (studentsToTake == null)
            {
                studentsToTake = courses[courseName].StudentsByName.Count;
            }

            Dictionary<string, double> marks =
                courses[courseName].StudentsByName.ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);
                sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
        }
    }
}
