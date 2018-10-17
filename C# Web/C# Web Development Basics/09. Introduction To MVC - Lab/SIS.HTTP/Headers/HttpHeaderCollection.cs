namespace SIS.HTTP.Headers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SIS.HTTP.Headers.Contracts;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            if (header == null || string.IsNullOrEmpty(header.Key) ||
                string.IsNullOrEmpty(header.Value) || this.ContainsHeader(header.Key))
            {
                throw new Exception();
            }

            headers[header.Key] = header;
        }

        public bool ContainsHeader(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException($"{nameof(key)} cannot be null");
            }

            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException($"{nameof(key)} cannot be null");
            }

            if (!this.headers.ContainsKey(key))
            {
                return null;
            }

            return this.headers[key];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var kvp in this.headers)
            {
                var headerKey = kvp.Key;
                var headerValue = kvp.Value;

                sb.AppendLine($"{headerKey}: {headerValue.Value}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
