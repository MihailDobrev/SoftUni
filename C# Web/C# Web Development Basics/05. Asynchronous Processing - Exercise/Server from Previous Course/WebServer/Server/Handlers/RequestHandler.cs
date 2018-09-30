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

        protected RequestHandler(Func<IHttpRequest, IHttpResponse> handlingFunc)
        {
            CoreValidator.ThrowIfNull(handlingFunc, nameof(handlingFunc));
            this.handlingFunc = handlingFunc;
        }
        public IHttpResponse Handle(IHttpContext httpContext)
        {
            var response = this.handlingFunc(httpContext.Request);

            if (!response.HeaderCollection.ContainsKey("Content-Type"))
            {
                response.HeaderCollection.Add(new HttpHeader("Content-Type", "text/html"));
            }

            return response;
        }
    }
}
