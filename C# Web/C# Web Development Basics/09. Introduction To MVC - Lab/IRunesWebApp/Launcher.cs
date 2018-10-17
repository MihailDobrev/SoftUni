namespace IRunesWebApp
{
    using SIS.Framework;
    using SIS.Framework.Routes;
    using SIS.WebServer;
    using SIS.WebServer.Api.Contracts;

    public class Launcher
    {
        public static void Main(string[] args)
        {
            IHttpHandler handler = new ControllerRouter();
            Server server = new Server(8000, handler);
            var engine = new MvcEngine();
            engine.Run(server);
        }

    }
}
