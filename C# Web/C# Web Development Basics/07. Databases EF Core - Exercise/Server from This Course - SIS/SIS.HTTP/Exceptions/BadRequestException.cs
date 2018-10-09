namespace SIS.HTTP.Exceptions
{
    using SIS.HTTP.Enums;
    using System;

    public class BadRequestException : Exception
    {
        private const string DefaultMessage = "The Request was malformed or contains unsupported elements.";

        public const HttpResponseStatusCode StatusCode = HttpResponseStatusCode.BadRequest;

        public BadRequestException(string message = DefaultMessage)
            : base(message)
        {
        }

    }
}
