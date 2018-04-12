namespace P03_BarraksWars.Core.Command
{
    using _03BarracksFactory.Contracts;
    using System;

    public class FightCommand : Command, IExecutable
    {
        public FightCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
