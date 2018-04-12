namespace P07InfernoInfinity
{
    using P07InfernoInfinity.Contracts;
    using P07InfernoInfinity.Core;
    using P07InfernoInfinity.Data;
    using P07InfernoInfinity.Factories;

    public class StartUp
    {
        public static void Main()
        {
            IGemFactory gemFactory = new GemFactory();
            IWeaponFactory weaponFactory = new WeaponFactory();
            IRepository weaponRepository = new WeaponRepository();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(weaponRepository, weaponFactory, gemFactory);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
