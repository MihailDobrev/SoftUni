namespace WebServer
{
    using Server;
    using Server.Routing;
    using Application;
    using Server.Contracts;
    using Server.Routing.Contracts;

    public class Launcher:IRunnable
    {
        private WebServer webserver;

        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            IApplication app = new MainApplication();
            IAppRouteConfig routeConfig = new AppRouteConfig();
            app.Configure(routeConfig);
            this.webserver = new WebServer(1337, routeConfig);
            this.webserver.Run();
        }
    }
}
