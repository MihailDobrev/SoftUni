namespace IRunesWebApp.Controllers
{
    using SIS.Framework.ActionResults.Contracts;
    using SIS.Framework.Controllers;

    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
