namespace WebServer.Server.Exceptions
{
    using System;

    class InvalidResponseRexception : Exception
    {
        public InvalidResponseRexception(string message) 
            : base(message)
        {
        }
    }
}
