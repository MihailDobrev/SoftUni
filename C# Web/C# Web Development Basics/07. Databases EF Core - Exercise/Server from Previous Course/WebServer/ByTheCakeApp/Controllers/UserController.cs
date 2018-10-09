namespace WebServer.ByTheCakeApp.Controllers
{
    using System;

    using Server.HTTP;
    using Server.HTTP.Contracts;
    using Server.HTTP.Response;
    using Services;

    using Helpers;
    using Models;
    using ViewModels.User;

    public class UserController : Controller
    {
        private const string RegisterViewPath = @"Account\Register";
        private const string LoginViewPath = @"Account\Login";

        private readonly IUserService userservice;
        private readonly IOrderService orderService;

        public UserController()
        {
            this.userservice = new UserService();
            this.orderService = new OrderService();
        }
        public IHttpResponse Login()
        {
            SetDefaultViewData();
            return this.FileViewResponse(LoginViewPath);
        }

        public IHttpResponse Login(IHttpRequest request, LoginViewModel model)
        {

            string username = model.Username;
            string password = model.Password;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                this.AddError("You have empty fields");
                return this.FileViewResponse(LoginViewPath);
            }

            var success = this.userservice.FindUser(username, password);

            if (success)
            {
                this.LoginUser(request, username);
                return new RedirectResponse("/");
            }
            else
            {
                this.AddError("Invalid user details");
                return this.FileViewResponse(LoginViewPath);
            }

        }

        private void LoginUser(IHttpRequest req, string username)
        {
            req.Session.Add(SessionStore.currentUserKey, username);
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());
        }

        public IHttpResponse Profile(IHttpRequest request)
        {
            if (!request.Session.Contains(SessionStore.currentUserKey))
            {
                throw new InvalidOperationException("There is no logged in user.");
            }

            var username = request.Session.Get<string>(SessionStore.currentUserKey);

            ProfileViewModel profileViewModel = userservice.Profile(username);

            if (profileViewModel == null)
            {
                throw new InvalidOperationException($"The user {username} could not be found in the database");
            }

            this.ViewData["username"] = profileViewModel.Username;
            this.ViewData["registrationDate"] = profileViewModel.RegistrationDate.ToShortDateString();
            this.ViewData["totalOrders"] = profileViewModel.TotalOrders.ToString();

            return this.FileViewResponse(@"Account\Profile");
        }

        public IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Clear();
            return new RedirectResponse("/login");
        }

        private void SetDefaultViewData()
        {
            this.ViewData["authDisplay"] = "none";
        }
        public IHttpResponse Register()
        {
            SetDefaultViewData();
            return this.FileViewResponse(RegisterViewPath);
        }
        public IHttpResponse Register(IHttpRequest request, RegisterUserViewModel model)
        {
            SetDefaultViewData();

            string username = model.UserName;
            string password = model.Password;
            string confirmPassword = model.ConfirmPassword;

            if (username.Length < 3
                || password.Length < 3
                || confirmPassword != password)
            {
                this.AddError("Invalid user details");
                return this.FileViewResponse(RegisterViewPath);
            }

            var success = this.userservice.Create(username, password);

            if (success)
            {
                this.LoginUser(request, username);
                return new RedirectResponse("/");
            }
            else
            {
                this.AddError("This username is taken!");
                return this.FileViewResponse(RegisterViewPath);
            }
        }

      
    }
}
