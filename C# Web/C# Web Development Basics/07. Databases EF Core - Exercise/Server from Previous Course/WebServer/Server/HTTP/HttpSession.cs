namespace WebServer.Server.HTTP
{
    using System.Collections.Generic;
    using Server.Common;
    using Server.HTTP.Contracts;

    public class HttpSession : IHttpSession
    {
        private readonly IDictionary<string, object> values;

        public HttpSession(string id)
        {
            CoreValidator.ThrowIfNullOrEmpty(id, nameof(id));
            this.Id = id;
            values = new Dictionary<string, object>();
        }
        public string Id { get; private set; }

        public object Get(string key)
        {
             CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            if (!this.values.ContainsKey(key))
            {
                return null;
            }
            return this.values[key];
        }

        public T Get<T>(string  key)
            => (T)this.Get(key);

        public void Add(string key, object value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNull(value, nameof(value));

            this.values[key] = value;
        }

        public void Clear() => this.values.Clear();

        public bool Contains(string key)
        {
            return this.values.ContainsKey(key);
        }
    }
}
