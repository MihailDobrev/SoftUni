namespace SIS.WebServer
{
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Response;
    using SIS.HTTP.Response.Contracts;
    using SIS.HTTP.Sessions;
    using SIS.WebServer.Routing;
 

    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly ServerRoutingTable serverRoutingTable;

        public ConnectionHandler(Socket client, ServerRoutingTable serverRoutingTable)
        {
            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }

        public async Task ProcessRequestAsync()
        {
            var httpRequest = await this.ReadRequest();

            if (httpRequest != null)
            {
                string sessionId = this.SetRequestSession(httpRequest);
                IHttpResponse httpResponse = this.HandleRequest(httpRequest);
                this.SetResponseSession(httpResponse, sessionId);
                await this.PrepareResponse(httpResponse);
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task PrepareResponse(IHttpResponse httpResponse)
        {
            byte[] byteSegments = httpResponse.GetBytes();

            WriteResponseToConsole(byteSegments);
        
            await this.client.SendAsync(byteSegments, SocketFlags.None);
        }

        private IHttpResponse HandleRequest(IHttpRequest httpRequest)
        {
            if (!this.serverRoutingTable.Routes.ContainsKey(httpRequest.RequestMethod)
                || !this.serverRoutingTable.Routes[httpRequest.RequestMethod].ContainsKey(httpRequest.Path))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            return this.serverRoutingTable.Routes[httpRequest.RequestMethod][httpRequest.Path].Invoke(httpRequest);
        }

        private async Task<IHttpRequest> ReadRequest()
        {
            var result = new StringBuilder();

            ArraySegment<byte> data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                var numberOfBytesRead = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

                if (numberOfBytesRead == 0)
                {
                    break;
                }

                string bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);

                result.Append(bytesAsString);

                if (numberOfBytesRead < 1023)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }

        private string SetRequestSession(IHttpRequest httpRequest)
        {
            string sessionId = null;

            if (httpRequest.CookieCollection.ContainsCookie(HttpSessionStorage.SessionCookieKey))
            {
                var cookie = httpRequest.CookieCollection.GetCookie(HttpSessionStorage.SessionCookieKey);
                sessionId = cookie.Value;
                httpRequest.Session = HttpSessionStorage.GetSession(sessionId);
            }
            else
            {
                sessionId = Guid.NewGuid().ToString();
                httpRequest.Session = HttpSessionStorage.GetSession(sessionId);
            }
            return sessionId;
        }

        private void SetResponseSession(IHttpResponse httpResponse, string sessionId)
        {
            if (sessionId != null)
            {
                httpResponse
                    .AddCookie(new HttpCookie(HttpSessionStorage.SessionCookieKey, $"{sessionId}"));
            }
        }

        private void WriteResponseToConsole(byte[] byteSegments)
        {
            Console.WriteLine("===RESPONSE===");
            Console.WriteLine(Encoding.UTF8.GetString(byteSegments, 0, byteSegments.Length));
        }

    }
}