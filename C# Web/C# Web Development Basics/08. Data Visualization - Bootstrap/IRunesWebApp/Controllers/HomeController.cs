namespace IRunesWebApp.Controllers
{
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Response.Contracts;

    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            if (this.IsAuthenticated(request))
            {
                var username = this.GetUser(request);
                this.ViewBag[Username] = username;
                this.Authenticated = true;
                return this.View("IndexLoggedIn");
            }

            return this.View();
        }
    }
}
