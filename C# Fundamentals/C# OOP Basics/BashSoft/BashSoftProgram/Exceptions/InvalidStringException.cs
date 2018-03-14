namespace BashSoftProgram.Exceptions
{
    using System;
    public class InvalidStringException:Exception
    {
        public const string NullOrEmptyValue = "The value of the variable CANNOT be null or empty!";

        public InvalidStringException()
            : base(NullOrEmptyValue)
        {
        }

        public InvalidStringException(string message)
            : base(message)
        {
        }
    }
}
