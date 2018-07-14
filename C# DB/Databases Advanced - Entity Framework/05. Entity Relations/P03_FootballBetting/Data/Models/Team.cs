using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
            HomeGames = new HashSet<Game>();
            AwayGames = new HashSet<Game>();
        }
        [Key]
        public int TeamId { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string Initials { get; set; }

        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }

        public Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }

        public Color SecondaryKitColor { get; set; }

        [ForeignKey("Town")]
        public int TownId { get; set; }

        public Town Town { get; set; }

        public ICollection<Player> Players { get; set; }

        [InverseProperty("HomeTeam")]
        public ICollection<Game> HomeGames { get; set; }

        [InverseProperty("AwayTeam")]
        public ICollection<Game> AwayGames { get; set; }
    }
}
