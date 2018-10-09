namespace WebServer.ByTheCakeApp.Services
{
    using ViewModels.User;

    public interface IUserService
    {
        bool Create(string username, string password);

        bool FindUser(string username, string password);

        ProfileViewModel Profile(string username);

        int? GetUserId(string username);
    }
}
