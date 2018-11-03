using MishMash.Data;
using SIS.Framework.ActionResults;
using SIS.Framework.Controllers;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;

namespace MishMash.App.Controllers
{
    public class BaseController:Controller
    {
        protected MishMashDbContext db;

        public BaseController(MishMashDbContext context)
        {
            this.db = context;
        }
        protected override IViewable View([CallerMemberName] string actionName = "")
        {
            if (this.IsAuthenticated())
            {
                if (this.IsAdmin())
                {
                    this.Model.Data.Add("LoggedIn", "none");
                    this.Model.Data.Add("IsAdmin", "block");
                }
                else
                {
                    this.Model.Data.Add("LoggedIn", "block");
                    this.Model.Data.Add("IsAdmin", "none");
                }

                this.Model.Data.Add("NotLoggedIn", "none");
                this.Model.Data.Add("Username", this.GetCurentUserName());

            }
            else
            {
                this.Model.Data.Add("IsAdmin", "none");
                this.Model.Data.Add("LoggedIn", "none");
                this.Model.Data.Add("NotLoggedIn", "block");
            }

            return base.View(actionName);
        }

        protected bool IsAdmin()
            => this.Identity.Roles.Contains("Admin");


        protected bool IsAuthenticated()
        {
            bool userLoggedIn = this.Identity != null;

            if (!userLoggedIn)
            {
                return false;
            }

            return true;
        }

        protected string DecodeString(string input)
                 => WebUtility.UrlDecode(input);

        protected string GetCurentUserName() => this.Identity.Username ?? string.Empty;
    }
}
