namespace SIS.HTTP.Exceptions
{
    using SIS.HTTP.Enums;
    using System;

    public class InternalServerErrorException : Exception
    {
        private const string DefaultMessage = "The Server has encountered an error.";

        public const HttpResponseStatusCode StatusCode = HttpResponseStatusCode.InternalServerError;

        public InternalServerErrorException(string message = DefaultMessage)
           : base(message)
        {

        }
    }
}
