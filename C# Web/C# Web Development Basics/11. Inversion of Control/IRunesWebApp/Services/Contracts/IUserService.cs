namespace IRunesWebApp.Services.Contracts
{
    public interface IUserService
    {
        bool ExistsByUsernameAndPassword(string username, string password);

        bool ValdiateUserDetails(string username, string password, string confirmPassword, string email);

        void SaveUser(string username, string password, string email);
    }
}
