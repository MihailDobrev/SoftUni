using SIS.Framework;

namespace SIS.Demo
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            WebHost.Start(new StartUp());
        }
    }
}