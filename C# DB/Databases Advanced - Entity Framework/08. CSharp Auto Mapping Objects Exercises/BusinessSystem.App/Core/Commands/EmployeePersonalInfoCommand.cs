namespace BusinessSystem.App.Core.Commands
{
    using BusinessSystem.App.Core.Contracts;
    using BusinessSystem.App.Core.Dtos;
    using System;

    public class EmployeePersonalInfoCommand : ICommand
    {
        private IEmployeeController employeeController;

        public EmployeePersonalInfoCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);

            EmployeeInfoDto emmployeeInfoDto = employeeController.GetEmployeePersonalInfo(id);

            return $"ID: {emmployeeInfoDto.Id} - {emmployeeInfoDto.FirstName} {emmployeeInfoDto.LastName} - ${emmployeeInfoDto.Salary:F2}" + Environment.NewLine +
                    $"Birthday: {emmployeeInfoDto.Birthday}" + Environment.NewLine +
                    $"Address: {emmployeeInfoDto.Address}";
        }
    }
}
