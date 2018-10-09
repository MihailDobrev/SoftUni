namespace WebServer.Server.HTTP
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;
    using Server.Common;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        public readonly IDictionary<string, ICollection<HttpHeader>> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, ICollection<HttpHeader>>();
        }

        public void Add(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, nameof(header));

            if (!headers.ContainsKey(header.Key))
            {
                headers[header.Key] = new List<HttpHeader>();
            }

            this.headers[header.Key].Add(header);
        }

        public bool ContainsKey(string key)
        {
            CoreValidator.ThrowIfNull(key, nameof(key));

            return this.headers.ContainsKey(key);
        }

    
        public ICollection<HttpHeader> GetHeader(string key)
        {
            CoreValidator.ThrowIfNull(key, nameof(key));

            if (!this.headers.ContainsKey(key))
            {
                throw new InvalidOperationException($"The given key {key} is not present in the headers collection.");
            }

            return this.headers[key];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var kvp in this.headers)
            {
                var headerKey = kvp.Key;

                foreach (var headerValue in kvp.Value)
                {
                    sb.AppendLine($"{headerKey}: {headerValue.Value}");
                }
            }

            return sb.ToString();
        }
        public IEnumerator<ICollection<HttpHeader>> GetEnumerator()
         => this.headers.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.headers.Values.GetEnumerator();

    }
}
