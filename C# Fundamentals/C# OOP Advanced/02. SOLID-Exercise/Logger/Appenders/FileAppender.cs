namespace Logger
{
    using Models;

    internal class FileAppender : IAppender
    {
        private ILogFile logfile { get; }
        public ILayout Layout { get; }
        public ErrorLevel Level { get; }
        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logfile)
        {
            Layout = layout;
            Level = errorLevel;
            this.logfile = logfile;
            MessagesAppended = 0;
        }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            this.logfile.WriteToFile(formattedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;
            string reportLevel = this.Level.ToString();

            string result = $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {reportLevel}, Messages appended: {MessagesAppended}, File size: {this.logfile.Size}";
            return result;
        }
    }
}