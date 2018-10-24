namespace IRunesWebApp.Services
{
    using IRunesWebApp.Data;
    using IRunesWebApp.Models;
    using IRunesWebApp.Services.Contracts;
    using SIS.Framework.Services.Contracts;
    using System;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly IRunesDbContext context;
        private IHashService hashService;

        public UserService(IRunesDbContext context, IHashService hashService)
        {
            this.hashService = hashService;
            this.context = context;
        }

        public bool ExistsByUsernameAndPassword(string username, string password)
        {
            var hashedPassword = this.hashService.Hash(password);

            var user = this.context.Users
                .FirstOrDefault(u => u.Username == username && hashedPassword == u.Password);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        public bool ValdiateUserDetails(string username, string password, string confirmPassword, string email)
        {

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(email) ||
                this.context.Users.Any(u => u.Username == username) ||
                password != confirmPassword)
            {
                return false;
            }

            return true; ;
        }

        public void SaveUser(string username, string password, string email)
        {
            string hashedPassword = this.hashService.Hash(password);

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Username = username,
                Password = hashedPassword,
                Email = email
            };

            context.Users.Add(user);
            context.SaveChanges();

        }
    }
}
