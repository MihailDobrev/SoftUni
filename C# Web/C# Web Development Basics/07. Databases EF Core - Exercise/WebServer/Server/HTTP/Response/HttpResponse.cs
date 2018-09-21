namespace WebServer.Server.HTTP.Response
{
    using System.Text;
    using Enums;
    using HTTP.Contracts;

    public abstract class HttpResponse : IHttpResponse
    {
        private string StatusMessage => this.StatusCode.ToString();

        protected HttpResponse()
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.CookieCollection = new HttpCookieCollection();
        }

        public HttpHeaderCollection HeaderCollection { get; }

        public HttpCookieCollection CookieCollection { get; }

        public HttpStatusCode StatusCode { get; protected set; }


        public override string ToString()
        {
            StringBuilder response = new StringBuilder();

            response.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusMessage}");
            response.AppendLine(this.HeaderCollection.ToString());

            return response.ToString();
        }
    }
}
