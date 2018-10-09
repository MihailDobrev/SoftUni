namespace WebServer.Server.HTTP.Response
{
    using Server.Common;
    using Server.Enums;

    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl)
        {
            CoreValidator.ThrowIfNullOrEmpty(redirectUrl, nameof(redirectUrl));

            this.StatusCode = HttpStatusCode.Found;
            this.HeaderCollection.Add(new HttpHeader("Location",redirectUrl));
        }
    }
}
