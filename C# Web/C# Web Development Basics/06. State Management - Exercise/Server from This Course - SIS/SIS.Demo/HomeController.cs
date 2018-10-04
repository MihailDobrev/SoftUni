namespace SIS.Demo
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Response.Contracts;
    using SIS.WebServer.Results;

    public class HomeController
    {
        private const string randomContent = "<h1>Hello, World!</h1>";

        public IHttpResponse Index()
        {
            return new HtmlResult(randomContent, HttpResponseStatusCode.OK);
        }
    }
}
