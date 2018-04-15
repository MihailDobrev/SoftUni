namespace BashSoftProgram.Contracts
{
    using System.Collections.Generic;
    public interface IRequester
    {
        void GetStudentScoresFromCourse(string courseName, string userName);

        void GetAllStudentsFromCourse(string courseName);

        ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> cmp);

        ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> cmp);
    }
}
