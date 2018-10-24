namespace SIS.Framework.Controllers
{
    using SIS.Framework.ActionResults;
    using SIS.Framework.ActionResults.Contracts;
    using SIS.Framework.Utilities;
    using SIS.Framework.Views;
    using SIS.HTTP.Requests.Contracts;
    using System.Runtime.CompilerServices;
    using SIS.Framework.Models;

    public abstract class Controller
    {
        protected ViewModel Model { get; set; }

        public Model ModelState { get; } = new Model();

        public IHttpRequest Request { get; set; }

        protected Controller()
        {
            this.Model = new ViewModel();
        }

        protected void SignIn(string username)
        {
            this.Request.Session.AddParameter("auth", username);
        }

        protected void SignOut()
        {
            this.Request.Session.ClearParameters();
        }

        public bool IsAuthenticated()
        {
            if (this.Request.Session.ContainsParameter("auth"))
            {
                return true;
            }

            return false;
        }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            string controllerName = ControllerUtilities.GetControllerName(this);

            string fullyQualifiedName = ControllerUtilities
                .GetViewFullQualifiedName(controllerName, caller);

            var view = new View(fullyQualifiedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
              => new RedirectResult(redirectUrl);
     
    }
}
