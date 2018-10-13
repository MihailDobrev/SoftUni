namespace SIS.HTTP.Cookies
{
    using SIS.HTTP.Cookies.Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private const string cookieExists= "Cookie already exists";
        private IDictionary<string, HttpCookie> cookies;


        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            if (cookie == null)
            {
                throw new ArgumentNullException();
            }

            if (this.ContainsCookie(cookie.Key))
            {
                throw new Exception(cookieExists);
            }

            this.cookies.Add(cookie.Key, cookie);
        }

        public bool ContainsCookie(string key)  => cookies.ContainsKey(key);

        public HttpCookie GetCookie(string key)
        {
            if (!this.ContainsCookie(key))
            {
                return null;
            }

            return cookies[key];
        }

        public IEnumerator<HttpCookie> GetEnumerator()
        {
            foreach (var cookie in cookies)
            {
                yield return cookie.Value;
            }
        }

        public bool HasCookies() => this.cookies.Any();

        public override string ToString()
        {
            return string.Join(";", this.cookies.Values);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
