using System.Linq;
using Torshia.Models;
using Torshia.Models.Enums;
using Toshia.Data;

namespace Torshia.Services
{
    public class UserService : IUserService
    {
        private readonly TorshiaContext db;

        public UserService(TorshiaContext context)
        {
            db = context;
        }

        public bool CheckUserExists(string username, string password)
            => this.db.Users.Any(u => u.Username == username && u.Password == password);

        public bool RegisterUser(string username, string password, string email)
        {
            Role role = DecideRole();
            bool userExists = this.db.Users.Any(u => u.Username == username);

            if (userExists ||
                string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password))
            {
                return false;
            }

            var user = new User()
            {
                Username = username,
                Password = password,
                Email = email,
                Role = role
            };

            this.db.Users.Add(user);
            db.SaveChanges();

            return true;
        }

        public Role DecideRole()
        {
            return this.db.Users.Any() ? Role.User : Role.Admin;
        }

        public User FindUser(string username)
            => this.db.Users.FirstOrDefault(u => u.Username == username);

        public User FindUserById(int id)
          => this.db.Users.FirstOrDefault(u => u.Id == id);
    }
}
