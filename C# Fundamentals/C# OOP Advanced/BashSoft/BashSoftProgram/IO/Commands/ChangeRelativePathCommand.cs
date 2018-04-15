namespace BashSoftProgram.IO.Commands
{
    using BashSoftProgram.Attributes;
    using BashSoftProgram.Contracts;
    using BashSoftProgram.Exceptions;

    [Alias("cdrel")]
    public class ChangeRelativePathCommand : Command, IExecutable
    {
        [Inject]
        private IDirectoryManager inputOutputManager;
        public ChangeRelativePathCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (Data.Length != 2)
            {
                throw new InvalidCommandException(Input);
            }
            string relPath = Data[1];
            this.inputOutputManager.ChangeCurrentDirectoryRelative(relPath);
        }
    }
}
