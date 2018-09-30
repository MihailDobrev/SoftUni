namespace SIS.WebServer.Results
{
    using SIS.HTTP.Common;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Response;
    using System.Text;

    public class HtmlResult : HttpResponse
    {
        public HtmlResult(string content, HttpResponseStatusCode responseStatusCode)
            : base(responseStatusCode)
        {
            this.Headers.Add(new HttpHeader(GlobalConstants.ContentType, GlobalConstants.TextHtml));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
