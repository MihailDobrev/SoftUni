namespace Logger.Models
{
    using System;

    public class Error : IError
    {
        public Error(DateTime dateTime, ErrorLevel level, string message)
        {
            DateTime = dateTime;
            Level = level;
            Message = message;
        }
        public DateTime DateTime { get; }
        public string Message { get; }
        public ErrorLevel Level { get; }
    }
}
