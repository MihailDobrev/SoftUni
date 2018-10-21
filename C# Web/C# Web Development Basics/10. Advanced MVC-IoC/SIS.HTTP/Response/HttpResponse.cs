namespace SIS.HTTP.Response
{
    using System.Linq;
    using System.Text;
    using SIS.HTTP.Common;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Cookies.Contracts;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Extensions;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Headers.Contracts;
    using SIS.HTTP.Response.Contracts;

    public class HttpResponse: IHttpResponse
    {
        public HttpResponse(HttpResponseStatusCode responseStatusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.CookieCollection = new HttpCookieCollection();
            this.Content = new byte[0];
            this.StatusCode = responseStatusCode;
        }

        public IHttpHeaderCollection Headers { get; private set; }
        
        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpCookieCollection CookieCollection { get; set; }

        public byte[] Content { get; set; }

        public void AddCookie(HttpCookie cookie)
        {
            this.CookieCollection.Add(cookie);
        }
        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {       
            return Encoding.UTF8
                .GetBytes(this.ToString())
                .Concat(this.Content)
                .ToArray();
        }

        public override string ToString()
        {
            StringBuilder response = new StringBuilder();

            response.AppendLine($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}");
            response.AppendLine(this.Headers.ToString());
            response.ToString().TrimEnd();

            if (CookieCollection.HasCookies())
            {
                foreach (var httpCookie in CookieCollection)
                {
                    response.AppendLine($"{HttpCookie.SetCookie}: {httpCookie}");
                }

                response.AppendLine();
            }

            response.AppendLine();

            return response.ToString();
        }
    }
}
