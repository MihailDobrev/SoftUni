namespace BashSoftProgram.Models
{
    using BashSoftProgram.Contracts;
    using BashSoftProgram.Exceptions;
    using System.Collections.Generic;

    public class SoftUniCourse : ICourse
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string name;
        private Dictionary<string, IStudent> studentsByName;

        public SoftUniCourse(string name)
        {
            Name = name;
            studentsByName = new Dictionary<string, IStudent>();
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
        public IReadOnlyDictionary<string, IStudent> StudentsByName
        {
            get { return studentsByName; }
        }

        public int CompareTo(ICourse other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public override string ToString() => this.Name;

        public void EnrollStudent(IStudent student)
        {
            if (studentsByName.ContainsKey(student.UserName))
            {
                throw new DuplicateEntryInStructureException(student.UserName, Name);
            }

            studentsByName.Add(student.UserName, student);
        }
    }
}
