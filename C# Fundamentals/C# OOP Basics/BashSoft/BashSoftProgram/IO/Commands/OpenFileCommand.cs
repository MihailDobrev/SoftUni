namespace BashSoftProgram.IO.Commands
{
    using BashSoftProgram.Exceptions;
    using System.Diagnostics;

    public class OpenFileCommand : Command
    {
        public OpenFileCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager
            inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (Data.Length!=2)
            {
                throw new InvalidCommandException(Input);
            }
            string fileName = Data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);
        }
    }
}
