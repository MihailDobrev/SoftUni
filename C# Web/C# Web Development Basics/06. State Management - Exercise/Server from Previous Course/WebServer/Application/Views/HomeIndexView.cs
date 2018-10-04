namespace WebServer.Application.Views
{
    using Server.Contracts;

    public class HomeIndexView : IView
    {
        public string View()
        {
            return "<body><h1> Welcome </h1></body>";
        }
    }
}