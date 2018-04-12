namespace P07InfernoInfinity.Core.Commands
{
    using System;
    using P07InfernoInfinity.Contracts;

    public class EndCommand : Command
    {
        public EndCommand(string[] commandArgs, IRepository weaponRepository, IWeaponFactory weaponFactory, IGemFactory gemFactory) 
            : base(commandArgs, weaponRepository, weaponFactory, gemFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
