namespace WebServer.Server.HTTP.Response
{
    
    using Enums;
    using Exceptions;
    using Server.Contracts;

    public class ViewResponse : HttpResponse
    {
        private readonly IView view;

        public ViewResponse(HttpStatusCode statusCode, IView view)
        {
            this.ValidateStatusCode(statusCode);
            this.view = view;
            this.StatusCode = statusCode;

            this.HeaderCollection.Add(new HttpHeader("Content-Type", "text/html"));
        }

        private void ValidateStatusCode(HttpStatusCode statusCode)
        {
            int statusCodeNumber = (int)statusCode;

            if (299 < statusCodeNumber && statusCodeNumber < 400)
            {
                throw new InvalidResponseRexception("View responces need a status code between 300 and above");

            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} {this.view.View()}";
        }
    }
}
