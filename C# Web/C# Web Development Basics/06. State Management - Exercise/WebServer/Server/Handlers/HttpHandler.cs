namespace WebServer.Server.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Common;
    using Server.HTTP;
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
            try
            {
                const string loginPath = "/login";

                if (context.Request.Path != loginPath &&
                    (context.Request.Session == null ||
                    !context.Request.Session.Contains(SessionStore.currentUserKey)))
                {
                    return new RedirectResponse(loginPath);
                }

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
            }
            catch (Exception ex)
            {
                return new InternalServerErrorResponse(ex);
            }

            return new NotFoundResponse();
        }
    }
}
