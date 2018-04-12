namespace P07InfernoInfinity.Core.Commands
{
    using P07InfernoInfinity.Contracts;
    public class CreateCommand : Command
    {
        public CreateCommand(string[] commandArgs, IRepository weaponRepository, IWeaponFactory weaponFactory, IGemFactory gemFactory) 
            : base(commandArgs, weaponRepository, weaponFactory, gemFactory)
        {
        }

        public override string Execute()
        {
            string[] weaponArgs = CommandArgs[1].Split();
            IWeapon weapon =this.WeaponFactory.CreateWeapon(weaponArgs[0], weaponArgs[1], CommandArgs[2]);
            WeaponRepository.CreateWeapon(weapon);
            return null;
        }
    }
}
