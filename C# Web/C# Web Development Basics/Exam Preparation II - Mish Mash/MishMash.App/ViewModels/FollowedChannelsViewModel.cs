namespace MishMash.App.ViewModels
{
    public class FollowedChannelsViewModel
    {
        public int ChannelId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public int Followers { get; set; }
    }
}
