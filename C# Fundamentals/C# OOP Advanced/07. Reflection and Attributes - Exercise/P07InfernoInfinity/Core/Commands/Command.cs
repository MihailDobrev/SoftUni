namespace P07InfernoInfinity.Core.Commands
{
    using P07InfernoInfinity.Contracts;
    public abstract class Command : IExecutable
    {
        protected Command(string[] commandArgs, IRepository weaponRepository, IWeaponFactory weaponFactory, IGemFactory gemFactory)
        {
            CommandArgs = commandArgs;
            WeaponRepository = weaponRepository;
            WeaponFactory = weaponFactory;
            GemFactory = gemFactory;
        }

        public string[] CommandArgs { get; private set; }
        public IRepository WeaponRepository { get; private set; }
        public IWeaponFactory WeaponFactory { get; private set; }
        public IGemFactory GemFactory { get; private set; }
        public abstract string Execute();
    }
}
