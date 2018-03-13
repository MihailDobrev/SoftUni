namespace Forum.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User(int id, string username, string password, ICollection<int> postIds)
        {
            Id = id;
            Username = username;
            Password = password;
            PostIds = new List<int>(postIds);
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<int> PostIds { get; set; }
    }
}
