namespace BashSoftProgram.Contracts
{
    public interface IDatabase : IRequester,IFilteredTaker,IOrderedTaker
    {
        void LoadData(string fileName);
        void UnloadData();
    }
}
