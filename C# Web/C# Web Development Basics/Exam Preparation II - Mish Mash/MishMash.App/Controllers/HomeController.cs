using Microsoft.EntityFrameworkCore;
using MishMash.App.ViewModels;
using MishMash.Data;
using MishMash.Models;
using SIS.Framework.ActionResults;
using System.Collections.Generic;
using System.Linq;

namespace MishMash.App.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(MishMashDbContext context)
            : base(context)
        {
        }

        public IActionResult Index()
        {
            if (!this.IsAuthenticated())
            {
                return this.View();
            }

            //followed channels

            var followedUserChannels = this.db.UserChannels
                .Include(x => x.User)
                .Include(y => y.Channel)
                .Select(c => new
                {
                    Description = c.Channel.Description,
                    Name = c.Channel.Name,
                    Type = c.Channel.Type,
                    User = c.User.Username,
                    Tags = c.Channel.Tags,
                    Followers = c.Channel.ChannelUsers.Count
                }).Where(u => u.User == Identity.Username);

            var userChannelsViewModels = new List<UserChannelsViewModel>();

            foreach (var userChannel in followedUserChannels)
            {
                var userChannelsViewModel = new UserChannelsViewModel
                {
                    Name = userChannel.Name,
                    Description = userChannel.Description,
                    Followers = userChannel.Followers,
                    Type = userChannel.Type.ToString()
                };
                userChannelsViewModels.Add(userChannelsViewModel);
            }

            this.Model.Data["UserChannelsViewModels"] = userChannelsViewModels;

            //suggested channels

            List<Tag> followedUserChannelTags = new List<Tag>();

            foreach (var channel in followedUserChannels)
            {
                followedUserChannelTags.AddRange(channel.Tags);
            }


            var unfollowedChannels = this.db.Channels
              .Select(c => new 
              {
                  Id = c.Id,
                  Description = c.Description,
                  Name = c.Name,
                  Type = c.Type,
                  UserNames = c.ChannelUsers.Select(cu=>new
                  {
                     Username=cu.User.Username
                  }),
                  Tags = c.Tags,
                  Followers = c.ChannelUsers.Count
              }).Where(x=>x.UserNames.All(un=>un.Username.ToLower()!=Identity.Username.ToLower()));



            var suggestedUserChannelsViewModels = new List<SuggestedUserChannelsViewModel>();


            foreach (var userChannel in unfollowedChannels)
            {
                bool isAtleastOneTagEqual = false;

                foreach (var tag in userChannel.Tags)
                {
                    if (followedUserChannelTags.Any(t => t.Content == tag.Content))
                    {
                        isAtleastOneTagEqual = true;
                    }
                }
                if (!isAtleastOneTagEqual)
                {
                    continue;
                }

                var suggestedUserChannelsViewModel = new SuggestedUserChannelsViewModel
                {
                    ChannelId = userChannel.Id,
                    Name = userChannel.Name,
                    Description = userChannel.Description,
                    Followers = userChannel.Followers,
                    Type = userChannel.Type.ToString()
                };
                suggestedUserChannelsViewModels.Add(suggestedUserChannelsViewModel);
            }

            this.Model.Data["SuggestedUserChannelsViewModels"] = suggestedUserChannelsViewModels;


            //other channels

            var allNamesOfChannelsShown = userChannelsViewModels.Select(c => c.Name)
                .ToList();
            allNamesOfChannelsShown.AddRange(suggestedUserChannelsViewModels.Select(c => c.Name));


            var otherUserChannels = this.db.Channels
           .Select(c => new
           {
               Id = c.Id,
               Description = c.Description,
               Name = c.Name,
               Type = c.Type,
               UserNames = c.ChannelUsers.Select(cu => new
               {
                   Username = cu.User.Username
               }),
               Tags = c.Tags,
               Followers = c.ChannelUsers.Count
           }).Where(c => !IsNameOfChannelEqualToFollowedChannels(c.Name, allNamesOfChannelsShown));


            var otherUserChannelsViewModels = new List<OtherUserChannelsViewModel>();

            foreach (var userChannel in otherUserChannels)
            {
                var otherUserChannelsViewModel = new OtherUserChannelsViewModel
                {
                    ChannelId = userChannel.Id,
                    Name = userChannel.Name,
                    Description = userChannel.Description,
                    Followers = userChannel.Followers,
                    Type = userChannel.Type.ToString()
                };
                otherUserChannelsViewModels.Add(otherUserChannelsViewModel);
            }

            this.Model.Data["OtherUserChannelsViewModels"] = otherUserChannelsViewModels;

            return this.View();
        }

        private bool IsNameOfChannelEqualToFollowedChannels(string name, List<string> allNamesOfChannelsShown)
        {
            if (allNamesOfChannelsShown.Any(c=>c==name))
            {
                return true;
            }

            return false;
        }
    }
}
