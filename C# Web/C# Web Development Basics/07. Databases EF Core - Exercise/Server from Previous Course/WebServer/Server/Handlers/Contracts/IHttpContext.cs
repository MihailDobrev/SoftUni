namespace WebServer.Server.Handlers.Contracts
{
    using HTTP.Contracts;

    public interface IHttpContext
    {
        IHttpRequest Request { get; }
    }
}
