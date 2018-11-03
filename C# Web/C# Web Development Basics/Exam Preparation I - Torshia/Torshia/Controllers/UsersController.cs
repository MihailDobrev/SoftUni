using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Method;
using SIS.Framework.Security;
using System.Collections.Generic;
using Torshia.Models;
using Torshia.Models.Enums;
using Torshia.Services;
using Torshia.ViewModels;

namespace Torshia.Controllers
{
    public class UsersController : BaseController
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var userExists = this.userService.CheckUserExists(model.Username, model.Password);

            if (!userExists)
            {
                return this.RedirectToAction("/users/login");
            }

            User user = this.userService.FindUser(model.Username);

            this.SignIn(new IdentityUser
            {
                Username = model.Username,
                Roles = new List<string> {user.Role.ToString()}
            });

            return this.RedirectToAction("/");
        }

        public IActionResult Register() => this.View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            Role role = userService.DecideRole();
            bool userRegistered = this.userService.RegisterUser(model.Username, model.Password, model.Email);

            if (!userRegistered)
            {
                return this.RedirectToAction("users/register");
            }

            this.SignIn(new IdentityUser() { Email=model.Email, Username=model.Username, Roles= new List<string> { role.ToString()} });

            return RedirectToAction("/");
        }

        public IActionResult Logout()
        {
            this.SignOut();
            return this.RedirectToAction("/");
        }
    }
}
