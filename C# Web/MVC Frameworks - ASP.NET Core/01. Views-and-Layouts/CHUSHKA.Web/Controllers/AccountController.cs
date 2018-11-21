using System.Linq;
using System.Threading.Tasks;
using CHUSHKA.Models;
using CHUSHKA.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CHUSHKA.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<User> signInManager;

        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            var result = await this.signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }


            return this.View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            var user = new User
            {
                UserName = model.Username,
                FullName = model.Fullname,
                Email = model.Email
            };

            var result = this.signInManager.UserManager.CreateAsync(user, model.Password).Result;

            if (result.Succeeded)
            {
                if (this.signInManager.UserManager.Users.Count() == 1)
                {
                    var adminRoleExists = this.roleManager.RoleExistsAsync("Admin").Result;

                    if (!adminRoleExists)
                    {
                        var adminRoleResult = this.roleManager.CreateAsync(new IdentityRole("Admin")).Result;
                    }

                    var roleResult = this.signInManager.UserManager.AddToRoleAsync(user, "Admin").Result;

                    if (roleResult.Errors.Any())
                    {
                        return this.View();
                    }
                }
                else
                {
                    var roleResult = this.signInManager.UserManager.AddToRoleAsync(user, "User").Result;

                    if (roleResult.Errors.Any())
                    {
                        return this.View();
                    }
                }

                await this.signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }


            return this.View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
