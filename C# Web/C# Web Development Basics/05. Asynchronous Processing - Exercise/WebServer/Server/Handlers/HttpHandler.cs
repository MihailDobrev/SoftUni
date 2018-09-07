namespace WebServer.Server.Handlers
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Common;
    using Handlers.Contracts;
    using HTTP.Contracts;
    using HTTP.Response;
    using Routing.Contracts;

    public class HttpHandler : IRequestHandler
    {
        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig serverRouteConfig)
        {
            CoreValidator.ThrowIfNull(serverRouteConfig, nameof(serverRouteConfig));
            this.serverRouteConfig = serverRouteConfig;
        }

        public IHttpResponse Handle(IHttpContext context)
        {
            var requestPath = context.Request.Path;
            var registeredRoutes = this.serverRouteConfig.Routes[context.Request.RequestMethod];

            foreach (KeyValuePair<string, IRoutingContext> kvp in registeredRoutes)
            {
                string pattern = kvp.Key;
                Regex regex = new Regex(pattern);
                Match match = regex.Match(requestPath);

                if (!match.Success)
                {
                    continue;
                }

                foreach (string parameter in kvp.Value.Parameters)
                {
                    context.Request.AddUrlParameter(parameter, match.Groups[parameter].Value);
                }

                return kvp.Value.RequestHandler.Handle(context);
            }

            return new NotFoundResponse();
        }
    }
}
