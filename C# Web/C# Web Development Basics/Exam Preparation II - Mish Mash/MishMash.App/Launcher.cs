using MishMash.Data;
using MishMash.Models;
using MishMash.Models.Enums;
using SIS.Framework;
using System.Collections.Generic;

namespace MishMash.App
{
    public class Launcher
    {
        public static void Main()
        {
           //SeedData();

            WebHost.Start(new StartUp());
        }

        private static void SeedData()
        {
            var db = new MishMashDbContext();

            var user1 = new User
            {
                Username = "Gosho",
                Email = "gosho@abv.bg",
                Password = "123",
                Role = Role.User
            };

            var user2 = new User
            {
                Username = "Pesho",
                Email = "pesho@abv.bg",
                Password = "123",
                Role = Role.User
            };

            var user3 = new User
            {
                Username = "test",
                Email = "test@abv.bg",
                Password = "123",
                Role = Role.Admin
            };

            db.Add(user1);
            db.Add(user2);
            db.Add(user3);
            db.SaveChanges();

            var channel1 = new Channel
            {
                Name = "Markiplier",
                Description = "Gaming stuff",
                Tags = new List<Tag> { new Tag { Content = "games" }, new Tag { Content = "fun" }, new Tag { Content = "shooter" } },
                Type = Type.Game
            };

            var channel2 = new Channel
            {
                Name = "NiggaHigga",
                Description = "Comedy stuff",
                Tags = new List<Tag> { new Tag { Content = "laugh" }, new Tag { Content = "fun" }, new Tag { Content = "jokes" } },
                Type = Type.Other
            };

            var channel3 = new Channel
            {
                Name = "SoftUni",
                Description = "IT stuff",
                Tags = new List<Tag> { new Tag { Content = "programming" }, new Tag { Content = "IT" }, new Tag { Content = ".net" } },
                Type = Type.Lessons
            };

            var channel4 = new Channel
            {
                Name = "Trainings",
                Description = "Sports stuff",
                Tags = new List<Tag> { new Tag { Content = "exercises" }, new Tag { Content = "jogging" }, new Tag { Content = "sports" } },
                Type = Type.Motivation
            };

            db.Add(channel1);
            db.Add(channel2);
            db.Add(channel3);
            db.Add(channel4);
            db.SaveChanges();

            var userchannels1 = new UserChannels()
            {
                Channel = channel1,
                User = user1
            };

            var userchannels2 = new UserChannels()
            {
                Channel = channel2,
                User = user2
            };

            var userchannels3 = new UserChannels()
            {
                Channel = channel3,
                User = user2
            };

            var userchannels4 = new UserChannels()
            {
                Channel = channel1,
                User = user3
            };

            var userchannels5 = new UserChannels()
            {
                Channel = channel2,
                User = user3
            };
            var userchannels6 = new UserChannels()
            {
                Channel = channel4,
                User = user3
            };

            db.Add(userchannels1);
            db.Add(userchannels2);
            db.Add(userchannels3);
            db.Add(userchannels4);
            db.Add(userchannels5);
            db.SaveChanges();
        }
    }
}
