namespace SIS.Framework.Routes
{
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Response.Contracts;
    using SIS.WebServer.Api.Contracts;
    using System.Linq;

    public class HttpRouteHandler : IHttpHandlerContext
    {
        private static string[] ResourceExtensions = { ".js", ".css", ".ico" };

        public HttpRouteHandler(IHttpHandler controllerHandler, IHttpHandler resourceHandler)
        {
            ControllerHandler = controllerHandler;
            ResourcerHandler = resourceHandler;
        }

        public IHttpHandler ControllerHandler { get; }
        public IHttpHandler ResourcerHandler { get;  }

        public IHttpResponse Handle(IHttpRequest request)
        {
            if (this.IsResourseRequest(request))
            {
                return this.ResourcerHandler.Handle(request);
            }
            return this.ControllerHandler.Handle(request);
        }

        private bool IsResourseRequest(IHttpRequest httpRequest)
        {
            var requestPath = httpRequest.Path;

            if (requestPath.Contains('.'))
            {
                var requestPathExtension = requestPath.Substring(requestPath.LastIndexOf('.'));
                return ResourceExtensions.Contains(requestPathExtension);
            }

            return false;
        }
    }
}
