using MishMash.Models.Enums;
using System.Collections.Generic;

namespace MishMash.Models
{
    public class Channel
    {
        public Channel()
        {
            Tags = new HashSet<Tag>();
            ChannelUsers = new HashSet<UserChannels>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Type Type { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ICollection<UserChannels> ChannelUsers { get; set; }

    }
}