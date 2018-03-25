namespace Logger.Factories
{
    using Models;
    using System;
    public class AppenderFactory
    {
        const string DefaultFileName = "logfile.txt";
        private LayoutFactory LayoutFactory;
       

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            LayoutFactory = layoutFactory;
        }
        public  IAppender CreateAppender(string appenderType, string levelString, string layoutType)
        {

            ILayout layout = this.LayoutFactory.CreateLayout(layoutType);
            ErrorLevel errorLevel = this.ParseErrorLevel(levelString);

            IAppender appender = null;

            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, errorLevel);
                    break;
                case "FileAppender":
                    ILogFile logFile = new LogFile(DefaultFileName);
                    appender = new FileAppender(layout, errorLevel,logFile);
                    break;
                default:
                    throw new ArgumentException("Invalid Appender Type");
            }

            return appender;
        }

        private ErrorLevel ParseErrorLevel(string levelString)
        {
            try
            {
                object levelObj = Enum.Parse(typeof(ErrorLevel), levelString);
                return (ErrorLevel)levelObj;
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException("Invalid ErrorLevel Type!", ae);
            }
          
        }
    }
}
