namespace BusinessSystem.App.Core.Commands
{
    using BusinessSystem.App.Core.Contracts;

    public class SetManagerCommand : ICommand
    {
        private IManagerController managerController;
        public SetManagerCommand(IManagerController managerController)
        {
            this.managerController = managerController;
        }
        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);
            int managerId = int.Parse(args[1]);

            this.managerController.SetManager(employeeId, managerId);

            return $"Employee with id {managerId} was set to be the manager of employee with id {employeeId}";
        }
    }
}
