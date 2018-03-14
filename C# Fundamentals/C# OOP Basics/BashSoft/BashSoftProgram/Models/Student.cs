namespace BashSoftProgram.Models
{
    using BashSoftProgram.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        private string userName;
        private Dictionary<string, Course> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;

        public Student(string userName)
        {
            UserName = userName;
            enrolledCourses = new Dictionary<string, Course>();
            marksByCourseName = new Dictionary<string, double>();
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get { return marksByCourseName; }
        }

        public IReadOnlyDictionary<string, Course> EnrolledCourses
        {
            get { return enrolledCourses; }
        }

        public string UserName
        {
            get { return userName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                userName = value;
            }
        }

        public void EnrollInCourse(Course course)
        {
            if (EnrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(UserName, course.Name);
            }

            enrolledCourses.Add(course.Name, course);
        }

        public void SetMarkOnCourse(string courseName, params int[] scores)
        {
            if (!enrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();
            }

            if (scores.Length > Course.NumberOfTasksOnExam)
            {
                throw new ArgumentOutOfRangeException(ExceptionMessages.InvalidNumberOfScores);
            }
            marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        private double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam = scores.Sum() / (double)(Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask);

            double mark = percentageOfSolvedExam * 4 + 2;
            return mark;
        }
    }

}

