namespace IRunesWebApp.Controllers
{
    using IRunesWebApp.Models;
    using IRunesWebApp.Services;
    using IRunesWebApp.Services.Contracts;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Response.Contracts;
    using SIS.WebServer.Results;
    using System;
    using System.Linq;

    public class UserController : BaseController
    {
        private IHashService hashService;

        public UserController()
        {
            hashService = new HashService();
        }

        public IHttpResponse Register()
        {
            return GetView();
        }

        public IHttpResponse Register(IHttpRequest request)
        {
            var username = this.GetFormData(request, "username").Trim();
            var password = this.GetFormData(request, "password");
            var confirmPassword = this.GetFormData(request, "confirm-password");
            var email = this.GetFormData(request, "email").Trim();

            var httpResponse = ValdiateUserDetails(username, password, confirmPassword, email);

            if (httpResponse != null)
            {
                return httpResponse;
            }

            SaveUser(username, password, email);

            IHttpResponse response = new RedirectResult(HomeRoot);
            response = this.SignInUser(request, response, username);
            return response;
        }

        public IHttpResponse Login()
        {
            return GetView();
        }

        public IHttpResponse Login(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                var usernameOrEmail = this.GetFormData(request, "usernameOrEmail").Trim();
                var password = this.GetFormData(request, "password");

                var hashedPassword = this.hashService.Hash(password);

                var user = this.db.Users.FirstOrDefault(u => u.Username == usernameOrEmail && hashedPassword == u.Password ||
                                                      u.Email == usernameOrEmail && hashedPassword == u.Password);

                if (user == null)
                {
                    return new RedirectResult(LoginRoot);
                }

                IHttpResponse response = new RedirectResult(HomeRoot);
                response = this.SignInUser(request, response, user.Username);

                return response;
            }

            return new RedirectResult(LoginRoot);
        }

        private void SaveUser(string username, string password, string email)
        {
            string hashedPassword = this.hashService.Hash(password);

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Username = username,
                Password = hashedPassword,
                Email = email
            };

            db.Users.Add(user);
            db.SaveChanges();

        }

        private IHttpResponse ValdiateUserDetails(string username, string password, string confirmPassword, string email)
        {
            IHttpResponse httpResponse = null;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(email) ||
                db.Users.Any(u => u.Username == username) ||
                password != confirmPassword)
            {
                return new RedirectResult(RegisterRoot);
            }

            return httpResponse;
        }


        public IHttpResponse Logout(IHttpRequest request)
        {
            if (!request.Session.ContainsParameter(Username))
            {
                return null;
            }

            request.Session.ClearParameters();

            var cookie = request.CookieCollection.GetCookie(AuthCookie);

            if (cookie != null)
            {
                cookie.Delete();
            }

            this.Authenticated = false;

            var response = new RedirectResult(HomeRoot);
            return response;
        }
    }
}
