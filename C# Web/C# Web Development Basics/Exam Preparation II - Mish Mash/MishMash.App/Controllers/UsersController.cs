using System.Collections.Generic;
using System.Linq;
using MishMash.App.ViewModels;
using MishMash.Data;
using MishMash.Models;
using MishMash.Models.Enums;
using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Method;
using SIS.Framework.Security;

namespace MishMash.App.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(MishMashDbContext context)
            : base(context)
        {
        }

        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var userExists = this.db.Users.Any(u => u.Username == model.Username && u.Password == model.Password);

            if (!userExists)
            {
                return RedirectToAction("/users/login");
            }

            User user = this.db.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            this.SignIn(new IdentityUser
            {
                Username = model.Username,
                Roles = new List<string> { user.Role.ToString()},
                Id = user.Id.ToString()
            });

            return this.RedirectToAction("/");
        }

        public IActionResult Register() => this.View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            Role role = this.db.Users.Any() ? Role.User : Role.Admin;

            
            bool userRegistered = this.RegisterUser(model.Username, model.Password, model.ConfirmPassword, model.Email, role);

            if (!userRegistered)
            {
                return this.RedirectToAction("users/register");
            }

            User user = this.db.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            this.SignIn(new IdentityUser() { Email = user.Email, Username = user.Username, Roles = new List<string> { role.ToString() }, Id=user.Id.ToString() });

            return RedirectToAction("/");
        }

        private bool RegisterUser(string username, string password, string confirmPassword, string email, Role role)
        {
            var userExists = this.db.Users.Any(u => u.Username == username && u.Password == password);

            if (!userExists ||
               string.IsNullOrEmpty(username) ||
               string.IsNullOrEmpty(password) ||
               password!=confirmPassword)
            {
                return false;
            }

            var user = new User()
            {
                Username = username,
                Password = password,
                Email = email,
                Role = role
            };

            this.db.Users.Add(user);
            db.SaveChanges();

            return true;
        }

        public IActionResult Logout()
        {
            this.SignOut();
            return this.RedirectToAction("/");
        }

    }
}
