namespace IRunesWebApp.Controllers
{
    using SIS.Framework.ActionResults.Contracts;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Response.Contracts;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            //if (this.IsAuthenticated(request))
            //{
            //    var username = this.GetUser(request);
            //    this.ViewBag[Username] = username;
            //    this.Authenticated = true;
            //    return this.View("IndexLoggedIn");
            //}

            return this.View();
        }
    }
}
