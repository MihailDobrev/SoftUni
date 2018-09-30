namespace SIS.HTTP.Response.Contracts
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Headers.Contracts;

    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }

        IHttpHeaderCollection Headers { get; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);

        byte[] GetBytes();
    }
}
