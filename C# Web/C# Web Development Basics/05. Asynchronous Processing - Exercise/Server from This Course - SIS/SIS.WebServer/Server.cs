namespace SIS.WebServer
{
    using SIS.WebServer.Routing;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class Server
    {
        private const string LocalhostAddress = "127.0.0.1";

        private readonly int port;
        private readonly ServerRoutingTable serverRoutingTable;
        private readonly TcpListener listener;
        private bool isRunning;

        public Server(int port, ServerRoutingTable serverRoutingTable)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(LocalhostAddress), port);
            this.serverRoutingTable = serverRoutingTable;
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;
            Console.WriteLine($"Server started at http://{LocalhostAddress}:{port}");

            var task = Task.Run(this.ListenLoop);
            task.Wait();
        }

        public async Task ListenLoop()
        {
            while (this.isRunning)
            {
                Socket client = await this.listener.AcceptSocketAsync();
                ConnectionHandler connectionHandler = new ConnectionHandler(client, this.serverRoutingTable);
                var responseTask = connectionHandler.ProcessRequestAsync();
                responseTask.Wait();
            }
        }

    }
}
