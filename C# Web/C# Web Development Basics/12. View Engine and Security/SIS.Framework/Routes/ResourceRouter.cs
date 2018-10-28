namespace SIS.Framework.Routes
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Response;
    using SIS.HTTP.Response.Contracts;
    using SIS.WebServer.Api.Contracts;
    using SIS.WebServer.Results;
    using System.IO;

    public class ResourceRouter : IHttpHandler
    {

        public IHttpResponse Handle(IHttpRequest requst)
        {
            var httpRequestPath = requst.Path;
            var indexOfStartOfExtention = httpRequestPath.LastIndexOf('.');
            var indexOfStartOfNameOfResource = httpRequestPath.LastIndexOf(MvcContext.DirectorySeparator);

            //Example: .css
            var requestPathExtension = httpRequestPath.Substring(indexOfStartOfExtention);

            //Example: boostrap.css
            var resourceName = httpRequestPath.Substring(indexOfStartOfNameOfResource);


            var resourcePath = MvcContext.Get.RootDirectoryRelativePath +
                MvcContext.Get.ResourceFolderName +
                MvcContext.DirectorySeparator + requestPathExtension.Substring(1)+ MvcContext.DirectorySeparator +
                resourceName;

            if (!File.Exists(resourcePath))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            var fileContent = File.ReadAllBytes(resourcePath);

            return new InlineResourceResult(fileContent, HttpResponseStatusCode.OK);
        }
    }
}
