namespace WebServer
{
    using Server;
    using Server.Routing;
    using Server.Contracts;
    using Server.Routing.Contracts;

    using Application;
    using WebServer.ByTheCakeApp;

    public class Launcher:IRunnable
    {
        private WebServer webserver;

        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            IApplication app = new ByTheCakeApplication();
            IAppRouteConfig routeConfig = new AppRouteConfig();
            app.Configure(routeConfig);
            this.webserver = new WebServer(1337, routeConfig);
            this.webserver.Run();
        }
    }
}
