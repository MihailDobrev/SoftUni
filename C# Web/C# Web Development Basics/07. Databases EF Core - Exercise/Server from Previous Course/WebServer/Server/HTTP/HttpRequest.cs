namespace WebServer.Server.HTTP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using Common;
    using Enums;
    using Exceptions;
    using HTTP.Contracts;

    public class HttpRequest : IHttpRequest
    {
        private const string invalidRequestMessage = "Invalid request line";
        private const string host = "Host";
        private const string cookie = "Cookie";

        public IDictionary<string, string> FormData { get; private set; }

        public HttpHeaderCollection HeaderCollection { get; private set; }

        public HttpCookieCollection CookieCollection { get; private set; }

        public string Path { get; private set; }

        public IDictionary<string, string> QuerryParameters { get; private set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, string> UrlParameters { get; private set; }

        public IHttpSession Session { get; set; }

        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.HeaderCollection = new HttpHeaderCollection();
            this.UrlParameters = new Dictionary<string, string>();
            this.QuerryParameters = new Dictionary<string, string>();
            this.FormData = new Dictionary<string, string>();
            this.CookieCollection = new HttpCookieCollection();
            this.ParseRequest(requestString);
        }

        private void ParseRequest(string requestString)
        {
            string[] requestLines = requestString
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            if (!requestLines.Any())
            {
                throw new BadRequestException(invalidRequestMessage);
            }

            string[] requestLine = requestLines[0].Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (requestLine.Length != 3 || requestLine[2].ToLower() != "http/1.1")
            {
                throw new BadRequestException(invalidRequestMessage);
            }

            this.RequestMethod = this.ParseRequestMethod(requestLine[0].ToUpper());
            this.Url = requestLine[1];
            this.Path = this.Url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];

            this.ParseHeaders(requestLines);
            this.ParseCookies();
            this.SetSession();
            this.ParseParameters();

            if (this.RequestMethod == HttpRequestMethod.POST)
            {
                this.ParseQuerry(requestLines[requestLines.Length - 1], this.FormData);
            }
        }

        private void SetSession()
        {
            if (this.CookieCollection.ContainsKey(SessionStore.sessionCookieKey))
            {
                HttpCookie cookie = this.CookieCollection.Get(SessionStore.sessionCookieKey);
                string sessionId = cookie.Value;

                this.Session = SessionStore.Get(sessionId);
            }
        }

        private void ParseCookies()
        {
            if (this.HeaderCollection.ContainsKey(cookie))
            {
                var allCookes = this.HeaderCollection.GetHeader(cookie);

                foreach (var cookie in allCookes)
                {
                    if (!cookie.Value.Contains('='))
                    {
                        return;
                    }
                    var cookieParts = cookie.Value.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    if (!cookieParts.Any())
                    {
                        continue;
                    }
                    foreach (var cookiePart in cookieParts)
                    {
                        var cookieKeyValuePair = cookiePart.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                        if (cookieKeyValuePair.Length == 2)
                        {
                            var key = cookieKeyValuePair[0].Trim();
                            var value = cookieKeyValuePair[1].Trim();
                            this.CookieCollection.Add(new HttpCookie(key, value, false));
                        }
                    }
                  
                }
            }
        }

        private void ParseParameters()
        {
            if (!this.Url.Contains("?"))
            {
                return;
            }
            string querry = this.Url.Split('?')[1];

            this.ParseQuerry(querry, this.QuerryParameters);
        }

        private void ParseQuerry(string querry, IDictionary<string, string> dict)
        {
            if (!querry.Contains("="))
            {
                return;
            }

            string[] querryPairs = querry.Split(new char[] { '&' });

            foreach (string querryPair in querryPairs)
            {
                string[] querryKvp = querryPair.Split(new char[] { '=' });

                if (querryKvp.Length != 2)
                {
                    continue;
                }

                dict.Add(
                    WebUtility.UrlDecode(querryKvp[0]),
                    WebUtility.UrlDecode(querryKvp[1]));
            }
        }

        private void ParseHeaders(string[] requestLines)
        {
            int emptyLineAfterHeadersIndex = Array.IndexOf(requestLines, string.Empty);

            for (int i = 1; i < emptyLineAfterHeadersIndex; i++)
            {
                string[] headerParts = requestLines[i]
                    .Split(new[] { ": " }, StringSplitOptions.None);

                if (headerParts.Length != 2)
                {
                    throw new BadRequestException(invalidRequestMessage);
                }

                var headerKey = headerParts[0];
                var headerValue = headerParts[1].Trim();

                var header = new HttpHeader(headerKey, headerValue);

                this.HeaderCollection.Add(header);
            }

            if (!this.HeaderCollection.ContainsKey(host))
            {
                throw new BadRequestException(invalidRequestMessage);
            }

        }

        private HttpRequestMethod ParseRequestMethod(string requestMethod)
        {
            bool parsed = Enum.TryParse(requestMethod, out HttpRequestMethod result);

            if (!parsed)
            {
                throw new BadRequestException(invalidRequestMessage);
            }

            return result;
        }


        public void AddUrlParameter(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            if (!UrlParameters.ContainsKey(key))
            {
                this.UrlParameters.Add(key, value);
            }
            else
            {
                this.UrlParameters[key] = value;
            }
        }
    }
}
