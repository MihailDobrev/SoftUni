namespace WebServer.Server.HTTP.Response
{
    using Common;
    using Server.Enums;

    public class NotFoundResponse : ViewResponse
    {
        public NotFoundResponse()
            :base(HttpStatusCode.NotFound, new NotFoundView())
        {
            
        }
    }
}
