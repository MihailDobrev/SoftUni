namespace BusinessSystem.App.Core.Commands
{
    using BusinessSystem.App.Core.Contracts;
    using System;

    public class ExitCommand : ICommand
    {
        private IEmployeeController employeeController;

        public ExitCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            Environment.Exit(0);

            return null;
        }
    }
}
