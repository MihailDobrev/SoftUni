namespace BashSoftProgram.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IStudent : IComparable<IStudent>
    {
        string UserName { get; }
        IReadOnlyDictionary<string, double> MarksByCourseName { get; }
        IReadOnlyDictionary<string, ICourse> EnrolledCourses { get; }
        void EnrollInCourse(ICourse course);
        void SetMarkOnCourse(string courseName, params int[] scores);
        double CalculateMark(int[] scores);
    }
}
