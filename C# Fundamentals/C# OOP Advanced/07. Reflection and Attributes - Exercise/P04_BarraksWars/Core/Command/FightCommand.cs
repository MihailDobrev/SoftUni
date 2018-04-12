namespace P03_BarraksWars.Core.Command
{
    using _03BarracksFactory.Contracts;
    using System;

    public class FightCommand : Command, IExecutable
    {
        public FightCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
