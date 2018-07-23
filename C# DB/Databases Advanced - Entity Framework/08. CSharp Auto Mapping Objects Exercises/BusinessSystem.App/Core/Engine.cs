namespace BusinessSystem.App.Core
{
    using BusinessSystem.App.Core.Contracts;
    using BusinessSystem.Services.Contracts;
    using System;
    using Microsoft.Extensions.DependencyInjection;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            IDbInitializerService initialzeDb = this.serviceProvider.GetService<IDbInitializerService>();
            initialzeDb.InitializeDatabase();

            ICommandInterpreter commandInterpreter = this.serviceProvider.GetService<ICommandInterpreter>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string result = commandInterpreter.Read(input);
                Console.WriteLine(result);
            }
        }
    }
}
