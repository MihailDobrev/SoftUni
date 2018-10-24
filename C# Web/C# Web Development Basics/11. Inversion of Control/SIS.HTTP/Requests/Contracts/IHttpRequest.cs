namespace SIS.HTTP.Requests.Contracts
{
    using System.Collections.Generic;
    using SIS.HTTP.Cookies.Contracts;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers.Contracts;
    using SIS.HTTP.Sessions.Contracts;

    public interface IHttpRequest
    {
        string Path { get; }

        string Url { get; }

        IHttpSession Session { get; set; }

        IHttpCookieCollection CookieCollection { get; }

        Dictionary<string, object> FormData { get; }

        Dictionary<string, object> QuerryData { get; }

        IHttpHeaderCollection Headers { get; }

        HttpRequestMethod RequestMethod { get; }
    }
}
