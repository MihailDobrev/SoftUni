namespace SIS.WebServer
{
    using Api.Contracts;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class Server
    {
        private const string LocalhostAddress = "127.0.0.1";

        private readonly int port;
        private readonly TcpListener listener;
        private readonly IHttpHandler handler;
        private bool isRunning;

        public Server(int port, IHttpHandler handler)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(LocalhostAddress), port);
            this.handler = handler;
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;
            Console.WriteLine($"Server started at http://{LocalhostAddress}:{port}");

            while (isRunning)
            {
                Socket client = listener.AcceptSocketAsync().GetAwaiter().GetResult();

                Task.Run(() => ListenLoop(client));
            }
        }

        public async void ListenLoop(Socket client)
        {
            ConnectionHandler connectionHandler = new ConnectionHandler(client, this.handler);
            await connectionHandler.ProcessRequestAsync();
        }
    }
}
