namespace SIS.App
{
    using SIS.Framework;
    using SIS.Framework.Routes;
    using SIS.Framework.Services;
    using SIS.Framework.Services.Contracts;
    using SIS.WebServer;
    using SIS.WebServer.Api.Contracts;
    using System;
    using System.Collections.Generic;

    public class Launcher
    {
        public static void Main()
        {
            var dependencyDict = new Dictionary<Type, Type>();
            IDependencyContainer dependencyContainer = new DependencyContainer(dependencyDict);
            dependencyContainer.RegisterDependancy<IHashService, HashService>();
            dependencyContainer.RegisterDependancy<IUserCookieService, UserCookieService>();

            IHttpHandlerContext httpHandlerContext = new HttpRouteHandler(new ControllerRouter(dependencyContainer), new ResourceRouter());
            Server server = new Server(80, httpHandlerContext);
            var engine = new MvcEngine();
            engine.Run(server);
        }
    }
}
