using MishMash.Models.Enums;
using System;
using System.Collections.Generic;

namespace MishMash.Models
{
    public class User
    {
        public User()
        {
            FollowedChannels = new HashSet<UserChannels>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public ICollection<UserChannels> FollowedChannels { get; set; }

        public Role Role { get; set; }
    }
}
