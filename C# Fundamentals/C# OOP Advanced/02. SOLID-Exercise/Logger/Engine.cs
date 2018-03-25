namespace Logger
{
    using Factories;
    using System;

    public class Engine
    {
        public ILogger Logger;
        private ErrorFactory ErrorFactory;
        public Engine(ILogger logger, ErrorFactory errorFactory)
        {
            Logger = logger;
            ErrorFactory = errorFactory;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] errorArgs = input.Split('|');
                string level = errorArgs[0];
                string dateTime = errorArgs[1];
                string message = errorArgs[2];

                IError error = ErrorFactory.CreateError(dateTime, level, message);
                Logger.Log(error);
            }

            Console.WriteLine("Logger info");

            foreach (IAppender appender in Logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
