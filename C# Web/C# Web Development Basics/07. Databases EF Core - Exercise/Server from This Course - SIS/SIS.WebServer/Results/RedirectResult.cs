namespace SIS.WebServer.Results
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Response;

    public class RedirectResult : HttpResponse
    {
        private const string Location = "Location";
        public RedirectResult(string location)
            : base(HttpResponseStatusCode.SeeOther)
        {
            this.Headers.Add(new HttpHeader(Location, location));
        }
    }
}
