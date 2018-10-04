namespace WebServer.ByTheCakeApp.Controllers
{
    using ByTheCakeApp.Helpers;
    using ByTheCakeApp.Models;
    using Server.HTTP;
    using Server.HTTP.Contracts;
    using Server.HTTP.Response;

    public class UserController:Controller
    {
        public IHttpResponse Login()
        {
            this.ViewData["authDisplay"] = "none";
            this.ViewData["showError"] = "none";
           return this.FileViewResponse(@"Account/Login");
        }

        public IHttpResponse Login(IHttpRequest req)
        {
            const string formNameKey = "name";
            const string formPasswordKey = "password";

            if (!req.FormData.ContainsKey(formNameKey) ||
                !req.FormData.ContainsKey(formPasswordKey) )
            {
                return new BadRequestResponse();
            }

            var name = req.FormData[formNameKey];
            var password = req.FormData[formPasswordKey];

            if (string.IsNullOrWhiteSpace(name) ||
              string.IsNullOrWhiteSpace(password))
            {
                this.ViewData["error"] = "You have empty fields";
                this.ViewData["showError"] = "block";

                return this.FileViewResponse(@"Account\Login");
            }

            req.Session.Add(SessionStore.currentUserKey, name);
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());        

            return new RedirectResponse("/"); 
        }

        public IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Clear();
            return new RedirectResponse("/login");
        }
    }
}
