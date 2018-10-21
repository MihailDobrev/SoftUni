namespace SIS.WebServer.Api.Contracts
{
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Response.Contracts;

    public interface IHttpHandler
    {
        IHttpResponse Handle(IHttpRequest requst);
    }
}
