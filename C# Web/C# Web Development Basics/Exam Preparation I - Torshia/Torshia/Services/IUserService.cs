using Torshia.Models;
using Torshia.Models.Enums;

namespace Torshia.Services
{
    public interface IUserService
    {
        bool RegisterUser(string username, string password, string email);

        bool CheckUserExists(string username, string password);

        User FindUser(string username);

        Role DecideRole();

        User FindUserById(int id);
    }
}
