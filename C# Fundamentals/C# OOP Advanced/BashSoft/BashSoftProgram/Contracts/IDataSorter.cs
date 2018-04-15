namespace BashSoftProgram.Contracts
{
    using System.Collections.Generic;

    public interface IDataSorter
    {
        void OrderAndTake(Dictionary<string, double> studentsWithMarks, string comparison, int studentsToTake);
    }
}
