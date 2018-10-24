namespace SIS.WebServer.Api.Contracts
{
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Response.Contracts;

    public interface IHttpHandlerContext
    {
        IHttpHandler ControllerHandler { get;  }

        IHttpHandler ResourcerHandler { get; }

        IHttpResponse Handle(IHttpRequest request);
    }
}
