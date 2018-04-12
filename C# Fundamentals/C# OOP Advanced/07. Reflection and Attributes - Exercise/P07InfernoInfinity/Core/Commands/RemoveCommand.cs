namespace P07InfernoInfinity.Core.Commands
{
    using P07InfernoInfinity.Contracts;

    public class RemoveCommand : Command
    {
        public RemoveCommand(string[] commandArgs, IRepository weaponRepository, IWeaponFactory weaponFactory, IGemFactory gemFactory) 
            : base(commandArgs, weaponRepository, weaponFactory, gemFactory)
        {
        }
        public override string Execute()
        {
            this.WeaponRepository.RemoveGem(CommandArgs[1],int.Parse(CommandArgs[2]));
            return null;
        }
    }
}
