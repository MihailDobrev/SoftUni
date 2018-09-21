namespace WebServer.Server.Handlers
{
    using System;
    using Common;
    using Handlers.Contracts;
    using HTTP;
    using HTTP.Contracts;

    public abstract class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpRequest, IHttpResponse> handlingFunc;
        private const string contentType = "Content-Type";
        private const string setCookie = "Set-Cookie";

        protected RequestHandler(Func<IHttpRequest, IHttpResponse> handlingFunc)
        {
            CoreValidator.ThrowIfNull(handlingFunc, nameof(handlingFunc));
            this.handlingFunc = handlingFunc;
        }

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            string sendSessionId = null;

            if (!httpContext.Request.CookieCollection.ContainsKey(SessionStore.sessionCookieKey))
            {
                var sessionId = Guid.NewGuid().ToString();

                httpContext.Request.Session = SessionStore.Get(sessionId);

                sendSessionId = sessionId;
            }

            var response = this.handlingFunc(httpContext.Request);

            if (sendSessionId != null)
            {
                response.HeaderCollection.Add(new HttpHeader(setCookie, $"{SessionStore.sessionCookieKey}={sendSessionId}; HttpOnly; path=/"));
            }

            if (!response.HeaderCollection.ContainsKey(contentType))
            {
                response.HeaderCollection.Add(new HttpHeader(contentType, "text/plain"));
            }

            foreach (var cookie in response.CookieCollection)
            {
                response.HeaderCollection.Add(new HttpHeader(setCookie, cookie.ToString()));
            }

            return response;
        }
    }
}
