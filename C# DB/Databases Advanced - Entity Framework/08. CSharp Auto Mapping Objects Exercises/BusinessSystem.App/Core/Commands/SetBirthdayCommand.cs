namespace BusinessSystem.App.Core.Commands
{
    using BusinessSystem.App.Core.Contracts;
    using System;

    public class SetBirthdayCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public SetBirthdayCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);
            DateTime date = DateTime.ParseExact(args[1], "dd-MM-yyyy", null);

            this.employeeController.SetBirthday(id, date);

            return "Employee Birthday was set successfully!";
        }
    }
}
