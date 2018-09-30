namespace WebServer.Application.Views
{
    using WebServer.Server;
    using WebServer.Server.Contracts;

    public class UserDetailsView : IView
    {
        private readonly Model model;

        public UserDetailsView(Model model)
        {
            this.model = model;
        }

        public string View()
        {
            return $"<body> Hello, {model["name"]}!</body>";
        }
    }
}
