namespace BusinessSystem.App.Core.Contracts
{
    using BusinessSystem.App.Core.Dtos;

    public interface IManagerController
    {
        void SetManager(int employeeId, int managerId);

        ManagerDto ManagerInfo(int employeeId);
    }
}
