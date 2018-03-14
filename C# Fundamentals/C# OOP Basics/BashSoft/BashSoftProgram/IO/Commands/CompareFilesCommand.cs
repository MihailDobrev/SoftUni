namespace BashSoftProgram.IO.Commands
{
    using BashSoftProgram.Exceptions;
    public class CompareFilesCommand : Command
    {
        public CompareFilesCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) 
            : base(input, data, judge, repository, inputOutputManager)
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

                Judge.CompareContent(firstPath, secondPath);
            }
        }
    }
}
