namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Data.Models;

    public class FootballBettingContext:DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(
                entity =>
                {
                    entity.HasKey(k => new { k.GameId, k.PlayerId });
                });

            modelBuilder.Entity<Team>(
               entity =>
               {
                   entity.HasOne(t => t.PrimaryKitColor)
                       .WithMany(c => c.PrimaryKitTeams)
                       .HasForeignKey(c => c.PrimaryKitColorId)
                       .OnDelete(DeleteBehavior.Restrict);
               });

            modelBuilder.Entity<Team>(
             entity =>
             {
                 entity.HasOne(t => t.SecondaryKitColor)
                     .WithMany(c => c.SecondaryKitTeams)
                     .HasForeignKey(c => c.SecondaryKitColorId)
                     .OnDelete(DeleteBehavior.Restrict);
             });

            modelBuilder.Entity<Game>(
           entity =>
           {
               entity.HasOne(g=>g.HomeTeam)
                   .WithMany(t=>t.HomeGames)
                   .HasForeignKey(t=>t.HomeTeamId)
                   .OnDelete(DeleteBehavior.Restrict);
           });

            modelBuilder.Entity<Game>(
           entity =>
           {
               entity.HasOne(g => g.AwayTeam)
                   .WithMany(t => t.AwayGames)
                   .HasForeignKey(t => t.AwayTeamId)
                   .OnDelete(DeleteBehavior.Restrict);
           });
        }
    }
}
