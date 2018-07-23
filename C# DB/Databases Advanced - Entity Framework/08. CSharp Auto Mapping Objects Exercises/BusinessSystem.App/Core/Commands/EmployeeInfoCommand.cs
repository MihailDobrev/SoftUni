namespace BusinessSystem.App.Core.Commands
{
    using BusinessSystem.App.Core.Contracts;
    using BusinessSystem.App.Core.Dtos;

    public class EmployeeInfoCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public EmployeeInfoCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }
        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);

            EmployeeDto employeeInfo = this.employeeController.GetEmployeeInfo(id);

            return $"ID: {employeeInfo.Id} - {employeeInfo.FirstName} {employeeInfo.LastName} -  ${employeeInfo.Salary:F2}";
        }
    }
}
