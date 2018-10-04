namespace WebServer.Server.HTTP.Contracts
{
    using System.Collections.Generic;
    using Enums;

    public interface IHttpRequest
    {
        IDictionary<string, string> FormData { get; }

        HttpHeaderCollection HeaderCollection { get; }

        HttpCookieCollection CookieCollection { get; }

        string Path { get; }

        IDictionary<string, string> QuerryParameters { get; }

        HttpRequestMethod RequestMethod { get; }

        string Url { get; }

        Dictionary<string, string> UrlParameters { get; }

        void AddUrlParameter(string key, string value);

        IHttpSession Session { get; set; }
    }
}
