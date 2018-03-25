namespace Logger
{
    using System;

    public class ConsoleAppender:IAppender
    {
        public ConsoleAppender(ILayout layout, ErrorLevel errorLevel)
        {
            Layout = layout;
            Level = errorLevel;
            this.MessagesAppended = 0;
        }

        public ILayout Layout { get; }

        public ErrorLevel Level { get; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            Console.WriteLine(formattedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            string appenderType =this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;
            string level = this.Level.ToString();

            string result = $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {level}, Messages appended: {MessagesAppended}";
            return result;
        }
    }
}