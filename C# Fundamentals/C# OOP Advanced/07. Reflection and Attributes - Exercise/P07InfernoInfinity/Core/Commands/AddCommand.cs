namespace P07InfernoInfinity.Core.Commands
{
    using P07InfernoInfinity.Contracts;
    using P07InfernoInfinity.Weapons;

    public class AddCommand : Command
    {
        public AddCommand(string[] commandArgs, IRepository weaponRepository, IWeaponFactory weaponFactory, IGemFactory gemFactory) 
            : base(commandArgs, weaponRepository, weaponFactory, gemFactory)
        {
        }

        public override string Execute()
        {
            string[] gemArgs = CommandArgs[3].Split();
            IGem gem =GemFactory.CreateGem(gemArgs[0],gemArgs[1]);
            this.WeaponRepository.AddGem(CommandArgs[1], int.Parse(CommandArgs[2]), gem);
            return null;
        }
    }
}
