namespace SIS.Framework.ActionResults
{
    using SIS.Framework.ActionResults.Contracts;

    public class RedirectResult : IRedirectable
    {
        public string RedirectUrl { get; }

        public RedirectResult(string redirectUrl)
        {
            this.RedirectUrl = redirectUrl;
        }
        public string Invoke()
                => this.RedirectUrl;
    }
}
