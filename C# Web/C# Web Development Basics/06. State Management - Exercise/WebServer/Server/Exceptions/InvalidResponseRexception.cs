namespace WebServer.Server.Exceptions
{
    using System;

    public class InvalidResponseRexception : Exception
    {
        public InvalidResponseRexception(string message) 
            : base(message)
        {
        }
    }
}
