namespace P07InfernoInfinity.Core
{
    using P07InfernoInfinity.Contracts;
    using System;

    public class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                string[] commandArgs = Console.ReadLine().Split(';');
                string result = commandInterpreter.InterpretCommand(commandArgs);
                if (result!=null)
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}
