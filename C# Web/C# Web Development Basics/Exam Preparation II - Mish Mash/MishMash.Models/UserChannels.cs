namespace MishMash.Models
{
    public class UserChannels
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int ChannelId { get; set; }

        public Channel Channel { get; set; }
    }
}
