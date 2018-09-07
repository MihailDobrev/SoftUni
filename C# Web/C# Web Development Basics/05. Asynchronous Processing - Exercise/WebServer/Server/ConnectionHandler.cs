namespace WebServer.Server
{
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    using Server.Common;
    using Server.Handlers;
    using Server.Handlers.Contracts;
    using Server.HTTP;
    using Server.Routing.Contracts;

    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IServerRouteConfig serverRouteConfig;

        public ConnectionHandler(Socket client, IServerRouteConfig serverRouteConfig)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(serverRouteConfig, nameof(serverRouteConfig));
            this.client = client;
            this.serverRouteConfig = serverRouteConfig;
        }

        public async Task ProcessRequestAsync()
        {
            string httpRequest = await this.ReadRequest();

            if (httpRequest!=null)
            {
                IHttpContext httpContext = new HttpContext(httpRequest);


                var httpResponse = new HttpHandler(this.serverRouteConfig).Handle(httpContext);

                ArraySegment<byte> toBytes = new ArraySegment<byte>(Encoding.UTF8.GetBytes(httpResponse.ToString()));

                await this.client.SendAsync(toBytes, SocketFlags.None);

                Console.WriteLine($"--REQUEST---");
                Console.WriteLine(httpRequest);
                Console.WriteLine($"--RESPONSE---");
                Console.WriteLine(httpResponse);

            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<string> ReadRequest()
        {
            var result = new StringBuilder();

            ArraySegment<byte> data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                var numberOfBytesRead = await this.client.ReceiveAsync(data, SocketFlags.None);


                if (numberOfBytesRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);

                result.Append(bytesAsString);

                if (numberOfBytesRead < 1024)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            return result.ToString();

        }
    }
}
