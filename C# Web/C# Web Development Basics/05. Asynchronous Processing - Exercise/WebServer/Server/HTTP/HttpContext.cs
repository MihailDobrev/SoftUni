namespace WebServer.Server.HTTP
{
    using Server.Handlers.Contracts;
    using HTTP.Contracts;
    using Server.Common;

    public class HttpContext:IHttpContext
    {
        public readonly IHttpRequest request;

        public HttpContext(string requestStr)
        {
            CoreValidator.ThrowIfNull(requestStr, nameof(requestStr));

            this.request = new HttpRequest(requestStr);
        }

        public IHttpRequest Request => this.request;
    }
}
