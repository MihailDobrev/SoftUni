namespace BashSoftProgram.Models
{
    using BashSoftProgram.Contracts;
    using BashSoftProgram.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniStudent : IStudent 
    {
        private string userName;
        private Dictionary<string, ICourse> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;

        public SoftUniStudent(string userName)
        {
            UserName = userName;
            enrolledCourses = new Dictionary<string, ICourse>();
            marksByCourseName = new Dictionary<string, double>();
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get { return marksByCourseName; }
        }

        public IReadOnlyDictionary<string, ICourse> EnrolledCourses
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

        public void EnrollInCourse(ICourse course)
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

            if (scores.Length > SoftUniCourse.NumberOfTasksOnExam)
            {
                throw new ArgumentOutOfRangeException(ExceptionMessages.InvalidNumberOfScores);
            }
            marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        public double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam = scores.Sum() / (double)(SoftUniCourse.NumberOfTasksOnExam * SoftUniCourse.MaxScoreOnExamTask);

            double mark = percentageOfSolvedExam * 4 + 2;
            return mark;
        }

        public int CompareTo(IStudent other)
        {
            return this.UserName.CompareTo(other.UserName);
        }

        public override string ToString() => this.UserName;
    }

}

