using System.Collections.Generic;
using Torshia.Models.Enums;

namespace Torshia.Models
{
    public class User
    {
        public User()
        {
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public ICollection<Report> Reports { get; set; }

        public Role Role { get; set; }
    }
}
