namespace SIS.HTTP.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SIS.HTTP.Common;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Cookies.Contracts;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Extensions;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Headers.Contracts;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Sessions.Contracts;

    public class HttpRequest : IHttpRequest
    {
        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QuerryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public IHttpSession Session { get; set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public IHttpCookieCollection CookieCollection { get; set; }

        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QuerryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.CookieCollection = new HttpCookieCollection();
            this.ParseRequest(requestString);
        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
               .Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0].Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseCookies();

            bool requestIsPOST = RequestMethod == HttpRequestMethod.Post;
            this.ParseRequestParameters(splitRequestContent.LastOrDefault(c => c != string.Empty), requestIsPOST);
        }

      
        private void ParseCookies()
        {
            if (this.Headers.ContainsHeader(HttpCookie.Cookie))
            {
                var cookieRaw = this.Headers.GetHeader(HttpCookie.Cookie).Value;
                var cookies = cookieRaw.Split("; ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var cookie in cookies)
                {
                    var cookieKeyValuePair = cookie.Split("=",2);

                    if (cookieKeyValuePair.Length!=2)
                    {
                        throw new BadRequestException();
                    }

                    var cookieName = cookieKeyValuePair[0];
                    var cookieValue = cookieKeyValuePair[1];

                    if (!CookieCollection.ContainsCookie(cookieName))
                    {
                        this.CookieCollection.Add(new HttpCookie(cookieName, cookieValue));
                    }
                }
            }
        }

        private bool IsValidRequestLine(string[] requestLine)
        {
            return requestLine.Length == 3 || requestLine[2].ToUpper() == GlobalConstants.HttpOneProtocolFragment;
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }

            bool parsed = Enum.TryParse(requestLine[0].Capitalize(), out HttpRequestMethod requestMethod);

            if (!parsed)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = requestMethod;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            if (string.IsNullOrEmpty(requestLine[1]))
            {
                throw new BadRequestException();
            }

            this.Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            var path = this.Url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];

            if (string.IsNullOrEmpty(path))
            {
                throw new BadRequestException();
            }

            this.Path = path;
        }

        private void ParseHeaders(string[] requestHeaders)
        {
            if (!requestHeaders.Any())
            {
                throw new BadRequestException();
            }

            foreach (var requestHeader in requestHeaders)
            {
                if (string.IsNullOrEmpty(requestHeader))
                {
                    continue;
                }

                string[] headerParts = requestHeader
                  .Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

                if (headerParts.Length!=2)
                {
                    continue;
                }

                var headerKey = headerParts[0];
                var headerValue = headerParts[1];

                this.Headers.Add(new HttpHeader(headerKey, headerValue));
            }

            if (!this.Headers.ContainsHeader(GlobalConstants.HostHeaderKey))
            {
                throw new BadRequestException();
            }

        }

        private void ParseRequestParameters(string formData, bool requestIsPOST)
        {
            this.ParseQuerryParameters();

            if (requestIsPOST)
            {
                this.ParseFormDataParameters(formData);
            }

        }

        private void ParseQuerryParameters()
        {
            if (!this.Url.Contains("?")|| this.Url.Split('?', StringSplitOptions.RemoveEmptyEntries).Length < 2)
            {
                return;
            }
          
            string queryParameters = this.Url
                        .Split('?')
                        .Skip(1)
                        .Take(1)
                        .ToArray()[0];

            if (!this.IsValidRequestQuerryString(queryParameters))
            {
                throw new BadRequestException();
            }

            ExtractRequestParameters(queryParameters, this.QuerryData);
        }


        private bool IsValidRequestQuerryString(string queryParameters)
        {
            if (string.IsNullOrEmpty(queryParameters))
            {
                return false;
            }

            return true;
        }

        private void ParseFormDataParameters(string formData)
        {
            ExtractRequestParameters(formData, this.FormData);
        }

        private void ExtractRequestParameters(string parameterData, Dictionary<string, object> parametersColletion)
        {
            string[] parameterDataPairs = parameterData.Split('&', StringSplitOptions.RemoveEmptyEntries);

            foreach (string parameterDataPair in parameterDataPairs)
            {
                string[] parameterDataKvp = parameterDataPair.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (parameterDataKvp.Length != 2)
                {
                    continue;
                }

                parametersColletion.Add(parameterDataKvp[0], parameterDataKvp[1]);
            }
        }

    }
}
