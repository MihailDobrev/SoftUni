namespace SIS.Framework
{
    using SIS.WebServer;
    using System;
    using System.Reflection;

    public class MvcEngine
    {
        public void Run(Server server)
        {
            RegisterAssemblyName();

            try
            {
                server.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void RegisterAssemblyName()
        {
            MvcContext.Get.AssemblyName = Assembly.GetEntryAssembly().GetName().Name;
        }
    }
}
