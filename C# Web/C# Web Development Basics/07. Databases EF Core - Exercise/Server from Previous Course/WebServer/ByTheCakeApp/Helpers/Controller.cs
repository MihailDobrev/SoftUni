namespace WebServer.ByTheCakeApp.Helpers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Views;
    using Server.Enums;
    using Server.HTTP.Contracts;
    using Server.HTTP.Response;

    public abstract class Controller
    {
        public const string DefaultPath = @"..\..\..\ByTheCakeApp\Resources\{0}.html";
        public const string ConentPlaceHolder = "{{{content}}}";

        protected IDictionary<string, string> ViewData { get; private set; }

        protected Controller()
        {
            this.ViewData = new Dictionary<string, string>()
            {
                ["showError"] = "none",
                ["authDisplay"] = "block"
            };          
        }

        protected void AddError(string errorMessage)
        {
            this.ViewData["showError"] = "block";
            this.ViewData["error"] = errorMessage;
        }

        private string ProcessFileHtml(string fileName)
        {
            var layout = File.ReadAllText(string.Format(DefaultPath, "Layout"));

            var fileHtml = File.ReadAllText(string.Format(DefaultPath, fileName));

            var result = layout.Replace("{{{content}}}", fileHtml);

            return result;
        }

        public IHttpResponse FileViewResponse(string fileName)
        {
            var result = this.ProcessFileHtml(fileName);

            if (this.ViewData.Any())
            {
                foreach (var value in ViewData)
                {
                    result = result.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
                }
            }

            return new ViewResponse(HttpStatusCode.OK, new FileView(result));
        }

    }
}
