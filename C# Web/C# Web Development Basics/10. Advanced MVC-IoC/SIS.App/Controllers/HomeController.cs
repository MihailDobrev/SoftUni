namespace SIS.App.Controllers
{
    using SIS.Framework.ActionResults.Contracts;
    using SIS.Framework.Controllers;

    public class HomeController : Controller
    {
        public IActionResult Index(IndexViewModel model)
        {
         
            return this.View();
        }
    }
}
