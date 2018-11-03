using Microsoft.EntityFrameworkCore;
using MishMash.App.ViewModels;
using MishMash.Data;
using MishMash.Models;
using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = MishMash.Models.Enums.Type;

namespace MishMash.App.Controllers
{
    public class ChannelsController : BaseController
    {
        public ChannelsController(MishMashDbContext context) : base(context)
        {
        }

        public IActionResult Details(int id)
        {
            if (!this.IsAuthenticated())
            {
                return this.View();
            }

            var channel = this.db.Channels.
                Select(c => new
                {
                    Id = c.Id,
                    Tags = string.Join(", ", c.Tags.Select(t => t.Content)),
                    Name = c.Name,
                    Description = c.Description,
                    ChannelUsers = c.ChannelUsers.Select(x => x.User).Count(),
                    Type = c.Type.ToString()
                }).FirstOrDefault(x => x.Id == id);

            var channelsDetailViewModel = new ChannelsDetailsViewModel
            {
                Tags = channel.Tags,
                Name = channel.Name,
                Description = channel.Description,
                Followers = channel.ChannelUsers,
                Type = channel.Type
            };


            this.Model.Data["ChannelsDetailViewModel"] = channelsDetailViewModel;

            return this.View();
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateChannelViewModel model)
        {
            if (!this.IsAuthenticated())
            {
                return this.View();
            }

            if (!this.IsAdmin())
            {
                return this.View();
            }

            bool enumParsed = Enum.TryParse(model.Type, true, out Type type);


            var channel = new Channel
            {
                Name = this.DecodeString(model.Name),
                Description = model.Description,
                Type = type
            };

            var tags = model.Tags.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var tag in tags)
            {
                var tagEntity = db.Tags.FirstOrDefault(t => t.Content == tag.Trim());

                if (tagEntity == null)
                {
                    var tagObject = new Tag
                    {
                        Content = tag.Trim()
                    };
                    this.db.Tags.Add(tagObject);
                    channel.Tags.Add(tagObject);
                }
                else
                {
                    channel.Tags.Add(tagEntity);
                }
            }
            this.db.Channels.Add(channel);
            db.SaveChanges();

            return this.RedirectToAction($"/channels/details/?id={channel.Id}");
        }

        public IActionResult Follow(int id)
        {

            if (!this.IsAuthenticated())
            {
                return this.View();
            }

            var user = this.db.Users.FirstOrDefault(x => x.Username == this.Identity.Username);

            var userChannel = new UserChannels
            {
                User = user,
                ChannelId = id
            };

            db.Add(userChannel);
            db.SaveChanges();

            return this.RedirectToAction("/");
        }
        public IActionResult Unfollow(int id)
        {

            if (!this.IsAuthenticated())
            {
                return this.View();
            }

            var userChannels = this.db.UserChannels
               .Include(x => x.User)
               .FirstOrDefault(c => c.ChannelId == id && c.User.Username == this.Identity.Username);

            db.Remove(userChannels);
            db.SaveChanges();
            return this.RedirectToAction("/");
        }

        public IActionResult Followed()
        {
            if (!this.IsAuthenticated())
            {
                return this.View();
            }

            var channels = this.db.Channels.
            Select(c => new
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Users = c.ChannelUsers.Select(x => x.User.Username),
                Followers = c.ChannelUsers.Select(x => x.User).Count(),
                Type = c.Type.ToString()
            })
            .Where(x => x.Users.Any(y => y == Identity.Username));

            List<FollowedChannelsViewModel> followedChannelsViewModels = new List<FollowedChannelsViewModel>();

            int counter = 0;

            foreach (var channel in channels)
            {
                counter++;
                var channelsDetailViewModel = new FollowedChannelsViewModel
                {
                    ChannelId = channel.Id,
                    Number = counter,
                    Name = channel.Name,
                    Description = channel.Description,
                    Followers = channel.Followers,
                    Type = channel.Type
                };
                followedChannelsViewModels.Add(channelsDetailViewModel);
            }

            this.Model.Data["FollowedChannelsViewModels"] = followedChannelsViewModels;

            return this.View();
        }

    }
}
