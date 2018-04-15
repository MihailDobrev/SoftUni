namespace BashSoftProgram.IO.Commands
{
    using BashSoftProgram.Contracts;
    using BashSoftProgram.Exceptions;
    using System;
    public abstract class Command : IExecutable
    {
        private string input;
        private string[] data;

        public Command(string input, string[] data)
        {
            Input = input;
            Data = data;
        }

        public string[] Data
        {
            get { return data; }
            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }
                data = value;
            }
        }

        public string Input
        {
            get { return input; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                input = value;
            }
        }
        public abstract void Execute();
    }
}
