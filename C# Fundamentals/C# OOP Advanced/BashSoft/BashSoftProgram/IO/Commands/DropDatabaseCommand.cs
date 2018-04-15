namespace BashSoftProgram.IO.Commands
{
    using BashSoftProgram.Attributes;
    using BashSoftProgram.Contracts;
    using BashSoftProgram.Exceptions;

    [Alias("dropdb")]
    public class DropDatabaseCommand : Command , IExecutable
    {
        [Inject]
        private IDatabase repository;
        public DropDatabaseCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (Data.Length != 1)
            {
                throw new InvalidCommandException(Input);
            }
            this.repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}
