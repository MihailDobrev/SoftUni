namespace WebServer.Server.HTTP.Response
{
    using System;
    using Server.Common;
    using Server.Enums;

    public class InternalServerErrorResponse : ViewResponse
    {
        public InternalServerErrorResponse(Exception ex, bool fullStackTrace = false)
            : base(HttpStatusCode.InternalServerError, new InternalServerErrorView(ex))
        {
        }
    }
}
