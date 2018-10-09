namespace SIS.HTTP.Cookies
{
    using System;

    public class HttpCookie
    {
        private const int HttpCookieDefaultExpirationInDays = 3;
        public const string Cookie = "Cookie";
        public const string SetCookie = "Set-Cookie";

        public string Key { get; }

        public string Value { get; }

        public DateTime Expires { get; set; }

        public bool IsHttpOnly { get; set; } = true;

        public bool IsNew { get; }

        public HttpCookie(string key, string value, int expiresInDays = HttpCookieDefaultExpirationInDays)
        {
            this.Key = key;
            this.Value = value;
            this.IsNew = true;
            this.Expires = DateTime.UtcNow.AddDays(expiresInDays);
        }

        public void Delete()
        {
            this.Expires = DateTime.UtcNow.AddDays(-1);
        }

        public HttpCookie(string key, string value, bool isNew, int expires = HttpCookieDefaultExpirationInDays)
            : this(key, value, expires)
        {
            this.IsNew = isNew;
        }

        public override string ToString()
        {
            var cookie = $"{this.Key}={this.Value}; Expires={this.Expires.ToString("R")}";

            if (IsHttpOnly)
            {
                cookie += "; HttpOnly";
            }
            return cookie;
        }
    }
}
