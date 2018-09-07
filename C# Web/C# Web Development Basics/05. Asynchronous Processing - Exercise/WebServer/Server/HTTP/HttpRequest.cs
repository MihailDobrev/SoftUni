namespace WebServer.Server.HTTP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Server.Common;
    using Server.Enums;
    using Server.Exceptions;
    using Server.HTTP.Contracts;

    public class HttpRequest : IHttpRequest
    {
        private const string invalidRequestMessage = "Invalid request line";

        public IDictionary<string, string> FormData { get; private set; }

        public HttpHeaderCollection HeaderCollection { get; private set; }

        public string Path { get; private set; }

        public IDictionary<string, string> QuerryParameters { get; private set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, string> UrlParameters { get; private set; }


        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.HeaderCollection = new HttpHeaderCollection();
            this.UrlParameters = new Dictionary<string, string>();
            this.QuerryParameters = new Dictionary<string, string>();
            this.FormData = new Dictionary<string, string>();
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
            this.ParseParameters();

            if (this.RequestMethod == HttpRequestMethod.POST)
            {
                this.ParseQuerry(requestLines[requestLines.Length - 1], this.FormData);
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

            string[] querryPairs = querry.Split(new char[] { '&' },StringSplitOptions.RemoveEmptyEntries);

            foreach (string querryPair in querryPairs)
            {
                string[] querryKvp = querryPair.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

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

            if (!this.HeaderCollection.ContainsKey("Host"))
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
