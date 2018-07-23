namespace BusinessSystem.App.Core.Commands
{
    using BusinessSystem.App.Core.Contracts;
    using System.Text;

    public class ListEmployeesOlderThanCommand : ICommand
    {
        private IEmployeeController controller;

        public ListEmployeesOlderThanCommand(IEmployeeController controller)
        {
            this.controller = controller;
        }
        public string Execute(string[] args)
        {
            int age = int.Parse(args[0]);
            var employeesOlderThanYear = this.controller.ListEmployeesOlderThan(age);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var employee in employeesOlderThanYear)
            {
                string managerName = employee.Manager == null ? "[no manager]" : employee.Manager.LastName;
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} - ${employee.Salary:F2} - Manager: {managerName}");
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
