namespace WebServer.Server.Routing
{
    using System.Collections.Generic;
    using Server.Handlers;
    using Server.Routing.Contracts;

    public class RoutingContext : IRoutingContext
    {
        public RoutingContext(RequestHandler requestHandler, IEnumerable<string> parameters)
        {
            Parameters = new List<string>();
            this.RequestHandler = requestHandler;
            this.Parameters = parameters;
        }
        public IEnumerable<string> Parameters { get; private set; }

        public RequestHandler RequestHandler { get; private set; }
    }
}
