namespace WebServer.Application.Controllers
{
    using Server.Enums;
    using Server.HTTP.Contracts;
    using Server.HTTP.Response;
    using WebServer.Application.Views;

    public class HomeController 
    {
        //GET/
        public IHttpResponse Index()
        {
            return new ViewResponse(HttpStatusCode.OK, new HomeIndexView());
        }
    }
}
