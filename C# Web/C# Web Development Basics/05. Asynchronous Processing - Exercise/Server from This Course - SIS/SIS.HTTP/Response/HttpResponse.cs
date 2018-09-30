namespace SIS.HTTP.Response
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Extensions;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Headers.Contracts;
    using SIS.HTTP.Response.Contracts;
    using System.Linq;
    using System.Text;

    public class HttpResponse: IHttpResponse
    {
        public HttpResponse(HttpResponseStatusCode responseStatusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
            this.StatusCode = responseStatusCode;
        }

        public IHttpHeaderCollection Headers { get; private set; }
        
        public HttpResponseStatusCode StatusCode { get; set; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {       
            return Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray();
        }

        public override string ToString()
        {
            StringBuilder response = new StringBuilder();

            response.AppendLine($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}");
            response.AppendLine(this.Headers.ToString());
            response.AppendLine();

            return response.ToString();
        }
    }
}
