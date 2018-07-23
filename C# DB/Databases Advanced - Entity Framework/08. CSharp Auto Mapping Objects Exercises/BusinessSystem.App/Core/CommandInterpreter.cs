namespace BusinessSystem.App.Core
{
    using BusinessSystem.App.Core.Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] input)
        {
            string commandName = input[0] + "Command";

            string[] args = input.Skip(1).ToArray();

            var commandType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandName);

            if (commandType ==null)
            {
                throw new ArgumentException("Command is invalid");
            }

            var constructor = commandType.GetConstructors().First();

            var constructorParameters = constructor.GetParameters()
                        .Select(c => c.ParameterType)
                        .ToArray();

            object[] service = constructorParameters.Select(serviceProvider.GetService).ToArray();

            ICommand command = (ICommand)constructor.Invoke(service);

            string result = command.Execute(args);

            return result;
        }
    }
}
