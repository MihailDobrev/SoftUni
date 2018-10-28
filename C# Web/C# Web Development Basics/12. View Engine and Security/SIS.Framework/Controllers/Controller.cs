namespace SIS.Framework.Controllers
{
    using SIS.Framework.ActionResults;
    using SIS.Framework.ActionResults.Contracts;
    using SIS.Framework.Utilities;
    using SIS.Framework.Views;
    using SIS.HTTP.Requests.Contracts;
    using System.Runtime.CompilerServices;
    using SIS.Framework.Models;
    using SIS.Framework.Security.Contracts;
    using System;

    public abstract class Controller
    {
        protected ViewModel Model { get; set; }
        private const string authenticaton = "auth";

        public Model ModelState { get; } = new Model();

        public IHttpRequest Request { get; set; }

        protected Controller()
        {
            this.Model = new ViewModel();
        }

        private ViewEngine ViewEngine { get; } = new ViewEngine();

        protected void SignIn(IIdentity identity)
        {
            this.Request.Session.AddParameter("auth", identity);
        }


        protected void SignOut()
        {
            this.Request.Session.ClearParameters();
        }

        public IIdentity Identity()
        {
            if (IsAuthenticated())
            {
                return (IIdentity) this.Request.Session.GetParameter(authenticaton);
            }

            return null;
        }
        public bool IsAuthenticated()
                => this.Request.Session.ContainsParameter(authenticaton);

        protected IViewable View([CallerMemberName] string viewName = "")
        {
            var controllerName = ControllerUtilities.GetControllerName(this);
            string viewContent = null;

            try
            {
                viewContent = this.ViewEngine.GetViewContent(controllerName, viewName);
            }
            catch (Exception e)
            {
                this.Model.Data["error"] = e.Message;

                viewContent = this.ViewEngine.GetErrorContent();
            }

            string renderedHtml = this.ViewEngine.RenderHtml(viewContent, this.Model.Data);
            var view = new View(renderedHtml);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
              => new RedirectResult(redirectUrl);
     
    }
}
