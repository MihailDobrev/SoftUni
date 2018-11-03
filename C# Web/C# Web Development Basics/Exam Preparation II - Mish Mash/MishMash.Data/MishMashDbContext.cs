using Microsoft.EntityFrameworkCore;
using MishMash.Models;

namespace MishMash.Data
{
    public class MishMashDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<UserChannels> UserChannels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MishMash;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserChannels>().HasKey(x => new {x.UserId, x.ChannelId});
        }
    }
}
