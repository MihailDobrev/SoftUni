namespace IRunesWebApp.Controllers
{
    using SIS.Framework.Controllers;
    using SIS.Framework.Attributes.Methods;
    using IRunesWebApp.ViewModels;
    using SIS.Framework.ActionResults.Contracts;
    using IRunesWebApp.Services.Contracts;
    using SIS.Framework.Security;

    public class UsersController : Controller
    {

        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (this.IsAuthenticated())
            {
                return RedirectToAction("/");
            }

            if (!ModelState.IsValid.HasValue && !ModelState.IsValid.Value)
            {
                return RedirectToAction("/Users/Register");
            }

            var username = model.Username.Trim();
            var password = model.Password;
            var confirmPassword = model.ConfirmPassword;
            var email = model.Email.Trim();

            var userExists = this.userService.ExistsByUsernameAndPassword(username, password);

            if (userExists)
            {
                return RedirectToAction("/Users/Register");
            }

            var isValidated = userService.ValdiateUserDetails(username, password, confirmPassword, email);

            if (!isValidated)
            {
                return RedirectToAction("/Home/Register");
            }

            userService.SaveUser(username, password, email);

            SignIn(new IdentityUser() { Username= username, Password=password});

            return RedirectToAction("/");
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (this.IsAuthenticated())
            {
                return RedirectToAction("/Home/Index");
            }

            if (!ModelState.IsValid.HasValue && !ModelState.IsValid.Value)
            {
                return RedirectToAction("/Users/Login");
            }

            var userExists = this.userService.ExistsByUsernameAndPassword(model.Username.Trim(), model.Password);


            if (!userExists)
            {
                return RedirectToAction("/Users/Login");
            }

            SignIn(new IdentityUser() { Username = model.Username, Password = model.Password });
            //this.SignIn(model.Username);

            return RedirectToAction("/");
        }
     


        //public IHttpResponse Logout(IHttpRequest request)
        //{
            //if (!request.Session.ContainsParameter(Username))
            //{
            //    return null;
            //}

            //request.Session.ClearParameters();

            //var cookie = request.CookieCollection.GetCookie(AuthCookie);

            //if (cookie != null)
            //{
            //    cookie.Delete();
            //}

            //this.Authenticated = false;

            //var response = new RedirectResult(HomeRoot);
            //return response;
        //}
    }
}
