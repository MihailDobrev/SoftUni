namespace IRunesWebApp.Controllers
{
    using SIS.HTTP.Response.Contracts;
    using SIS.WebServer.Results;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Requests.Contracts;
    using System.IO;
    using Microsoft.EntityFrameworkCore;    
    using IRunesWebApp.Data;
    using System.Runtime.CompilerServices;   
    using IRunesWebApp.Services;
    using System.Collections.Generic;
    using System.Net;

    public abstract class BaseController
    {
      
        private const string RootDirectoryRelativePath = "../../../";

        private const string ControllerDefaultName = "Controller";

        private const string ViewsFolderName = "Views";

        private const string DirectorySeparator = "/";

        private const string HtmlFileExtension = ".html";

        private string GetCurrentControllerName() => GetType().Name.Replace(ControllerDefaultName, string.Empty);

        protected const string Username = "username";

        protected const string AuthCookie = "IRunes-auth";

        protected const string HomeRoot = "/Home/Index";

        protected const string LoginRoot = "/Users/Login";

        protected const string RegisterRoot = "/Users/Register";

        protected const string CreateView = "Create";


        protected bool Authenticated { get; set; }

        protected IDictionary<string, string> ViewBag { get; set; }
       
        protected IRunesDbContext db { get; }

        protected UserCookieService userCookieService { get; }

        public BaseController()
        {
            this.db = new IRunesDbContext();
            db.Database.Migrate();
            ViewBag = new Dictionary<string, string>();
            userCookieService = new UserCookieService();
            Authenticated = false;
        }

        public bool IsAuthenticated(IHttpRequest request)
        {
            return request.Session.ContainsParameter(Username);
        }

        protected IHttpResponse SignInUser(IHttpRequest request, IHttpResponse response, string username)
        {
            request.Session.AddParameter(Username, username);
            var cookieContent = this.userCookieService.GetUserCookie(username);
            response.CookieCollection.Add(new HttpCookie(AuthCookie, cookieContent));
            return response;
        }

        protected string GetUser(IHttpRequest request)
        {
            var username = request.Session.GetParameter(Username);

            return username.ToString();
        }

        protected string GetFormData(IHttpRequest request, string data)
        {
            if (request.FormData.ContainsKey(data))
            {
                return request.FormData[data].ToString();
            }

            return null;
        }

        protected string DecodeString(string input)
                    =>WebUtility.UrlDecode(input);
       

        protected IHttpResponse View([CallerMemberName] string viewName = "")
        {
            string filePath = GetViewPath(viewName);

            var content = File.ReadAllText(filePath);

            var layout = string.Empty;

            if (this.Authenticated)
            {
                layout = File.ReadAllText(this.GetLayoutPath("_LayoutLoggedIn"));
            }
            else
            {
                layout = File.ReadAllText(this.GetLayoutPath("_Layout"));
            }

            var layoutWithContent = layout.Replace("{{{Content}}}", content);

            foreach (var viewBagKey in ViewBag.Keys)
            {
                var dynamicDataPlaceholder = $"{{{{{{{viewBagKey}}}}}}}";

                if (layoutWithContent.Contains(dynamicDataPlaceholder))
                {
                    layoutWithContent = layoutWithContent.Replace(dynamicDataPlaceholder, this.ViewBag[viewBagKey]);
                }
            }

            return new HtmlResult(layoutWithContent, HttpResponseStatusCode.OK);
        }

        private string GetLayoutPath(string viewName)
        {
            string filePath =
                             RootDirectoryRelativePath + // ../../../
                             ViewsFolderName +  // Views
                             DirectorySeparator + // /
                             viewName + HtmlFileExtension; // .html;
            return filePath;
        }

        private string GetViewPath(string viewName)
        {
            string filePath =
                            RootDirectoryRelativePath + // ../../../
                            ViewsFolderName +  // Views
                            DirectorySeparator + // /
                            this.GetCurrentControllerName() + // ControllerName
                            DirectorySeparator + // /
                            viewName + HtmlFileExtension; // .html;
            return filePath;
        }
    }
}
