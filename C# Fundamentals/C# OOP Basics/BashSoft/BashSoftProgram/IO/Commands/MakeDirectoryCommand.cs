namespace BashSoftProgram.IO.Commands
{
    using BashSoftProgram.Exceptions;
    public class MakeDirectoryCommand:Command
    {   
        public MakeDirectoryCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager
          inputOutputManager)
            : base(input, data, judge, repository, inputOutputManager)
        {

        }

        public override void Execute()
        {
            if (Data.Length != 2)
            {
                throw new InvalidCommandException(Input);
            }

            string folderName = Data[1];
            InputOutputManager.CreateDirectoryInCurentFolder(folderName);
        }
    }
}
