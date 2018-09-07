namespace WebServer.Application.Controllers
{
    using Server.HTTP.Contracts;
    using Server.HTTP.Response;
    using WebServer.Application.Views;
    using WebServer.Server;
    using WebServer.Server.Enums;

    public class UserController
    {
        //GET/
        public IHttpResponse RegisterGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new RegisterView());
        }

        //POST
        public IHttpResponse RegisterPost(string name)
        {
       
                return new RedirectResponse($"/user/{name}");
        }

        //GET/
        public IHttpResponse Details(string name)
        {
            Model model = new Model { ["name"] = name };
            if (name == string.Empty)
            {
                return this.RegisterGet();
            }
            return new ViewResponse(HttpStatusCode.OK, new UserDetailsView(model));
        }
    }
}
