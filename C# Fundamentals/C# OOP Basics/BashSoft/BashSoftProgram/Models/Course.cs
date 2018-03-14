namespace BashSoftProgram.Models
{
    using BashSoftProgram.Exceptions;
    using System.Collections.Generic;

    public class Course
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string name;
        private Dictionary<string, Student> studentsByName;

        public Course(string name)
        {
            Name = name;
            studentsByName = new Dictionary<string, Student>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                name = value;
            }
        }
        public IReadOnlyDictionary<string, Student> StudentsByName
        {
            get { return studentsByName; }
        }

        public void EnrollStudent(Student student)
        {
            if (studentsByName.ContainsKey(student.UserName))
            {
                throw new DuplicateEntryInStructureException(student.UserName, Name);
            }

            studentsByName.Add(student.UserName, student);
        }
    }
}
