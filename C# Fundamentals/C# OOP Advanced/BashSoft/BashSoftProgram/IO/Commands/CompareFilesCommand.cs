namespace BashSoftProgram.IO.Commands
{
    using BashSoftProgram.Attributes;
    using BashSoftProgram.Contracts;
    using BashSoftProgram.Exceptions;

    [Alias("cmp")]
    public class CompareFilesCommand : Command, IExecutable
    {
        [Inject]
        private IContentComparer judge;
        public CompareFilesCommand(string input, string[] data) 
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (Data.Length != 3)
            {
                throw new InvalidCommandException(Input);
            }
            else
            {
                string firstPath = Data[1];
                string secondPath = Data[2];

                this.judge.CompareContent(firstPath, secondPath);
            }
        }
    }
}
