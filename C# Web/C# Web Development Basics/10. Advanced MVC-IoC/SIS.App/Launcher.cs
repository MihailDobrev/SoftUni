namespace SIS.App
{
    using SIS.Framework;
    using SIS.Framework.Routes;
    using SIS.WebServer;
    using SIS.WebServer.Api.Contracts;

    public class Launcher
    {
        public static void Main()
        {
            IHttpHandlerContext httpHandlerContext = new HttpRouteHandler(new ControllerRouter(),new ResourceRouter());
            Server server = new Server(80, httpHandlerContext);
            var engine = new MvcEngine();
            engine.Run(server);
        }
    }
}
