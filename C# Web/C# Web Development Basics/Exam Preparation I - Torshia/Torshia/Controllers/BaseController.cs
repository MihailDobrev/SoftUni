using SIS.Framework.ActionResults;
using SIS.Framework.Controllers;
using System;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;

namespace Torshia.Controllers
{
    public class BaseController : Controller
    {
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
                this.Model.Data.Add("Username", this.Identity.Username);

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
       
        
    }
}
