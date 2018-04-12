namespace P07InfernoInfinity.Core.Commands
{
    using P07InfernoInfinity.Contracts;

    public class PrintCommand : Command
    {
        public PrintCommand(string[] commandArgs, IRepository weaponRepository, IWeaponFactory weaponFactory, IGemFactory gemFactory) 
            : base(commandArgs, weaponRepository, weaponFactory, gemFactory)
        {
        }

        public override string Execute()
        {
            return this.WeaponRepository.Print(CommandArgs[1]);
        }
    }
}
