namespace P07InfernoInfinity.Core
{
    using P07InfernoInfinity.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;
    public class CommandInterpreter : ICommandInterpreter
    {
        public CommandInterpreter(IRepository weaponRepository, IWeaponFactory weaponFactory, IGemFactory gemFactory)
        {
            WeaponRepository = weaponRepository;
            WeaponFactory = weaponFactory;
            GemFactory = gemFactory;
        }

        public IRepository WeaponRepository { get; private set; }
        public IWeaponFactory WeaponFactory { get; private set; }
        public IGemFactory GemFactory { get; private set; }

        public string InterpretCommand(string[] commandArgs)
        {
            string commandName = commandArgs[0].ToLower();
            Assembly assembly = Assembly.GetCallingAssembly();
            Type command = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName+"command");

            MethodInfo method = typeof(IExecutable).GetMethods().First();

            object[] constrArgs = new object[] { commandArgs, WeaponRepository, WeaponFactory, GemFactory };
            object instance = Activator.CreateInstance(command, constrArgs);

            try
            {
                string result = (string)method.Invoke(instance, null);
                return result;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }
    }
}
