namespace BashSoftProgram.IO.Commands
{
    using BashSoftProgram.Exceptions;
    using System;
    public abstract class Command
    {
        private string input;
        private string[] data;
        private Tester judge;
        private StudentsRepository repository;
        private IOManager inputOutputManager;

        public Command(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {
            Input = input;
            Data = data;
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        protected IOManager InputOutputManager
        {
            get { return inputOutputManager; }
        }

        protected StudentsRepository Repository
        {
            get { return repository; }
        }

        protected Tester Judge
        {
            get { return judge; }
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
