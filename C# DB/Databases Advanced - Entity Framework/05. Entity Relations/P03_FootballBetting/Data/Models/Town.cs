namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Town
    {
        public Town()
        {
            Teams = new HashSet<Team>();
        }

        [Key]
        public int TownId { get; set; }

        public string Name { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}