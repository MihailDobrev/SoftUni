namespace WebServer.Server.HTTP
{
    using Server.Handlers.Contracts;
    using HTTP.Contracts;
    using Server.Common;

    public class HttpContext:IHttpContext
    {
        public readonly IHttpRequest request;

        public HttpContext(IHttpRequest request)
        {
            CoreValidator.ThrowIfNull(request, nameof(request));

            this.request = request;
        }

        public IHttpRequest Request => this.request;
    }
}
