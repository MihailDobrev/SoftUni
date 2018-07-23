namespace BusinessSystem.App.Core.Commands
{
    using BusinessSystem.App.Core.Contracts;
    using System.Text;

    public class ManagerInfoCommand : ICommand
    {
        private IManagerController managerController;

         public ManagerInfoCommand(IManagerController managerController)
        {
            this.managerController = managerController;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);

            var managerDto = this.managerController.ManagerInfo(id);

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.EmployeeDtos.Count}");

            foreach (var employee in managerDto.EmployeeDtos)
            {
                stringBuilder.AppendLine($"    - {employee.FirstName} {employee.LastName} - ${employee.Salary:F2}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
