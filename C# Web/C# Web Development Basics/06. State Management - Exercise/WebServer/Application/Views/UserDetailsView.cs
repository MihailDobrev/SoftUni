namespace WebServer.Application.Views
{
    using Server;
    using Server.Contracts;

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
