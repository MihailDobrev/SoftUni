namespace WebServer.ByTheCakeApp.Controllers
{
    using Helpers;
    using Server.HTTP;
    using Server.HTTP.Contracts;

    public class HomeController : Controller
    {
        public IHttpResponse Index()
        {
            var response= this.FileViewResponse(@"Home\Index");
            response.CookieCollection.Add(new HttpCookie("lang", "en"));
            return response;
        }
        
        public IHttpResponse About() => this.FileViewResponse(@"Home\AboutUs");

    }
}
