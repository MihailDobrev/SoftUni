namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Bet
    {
        [Key]
        public int BetId { get; set; }

        public decimal Amount { get; set; }

        [Required]
        public string Prediction { get; set; }

        public DateTime DateTime { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }

        public Game Game { get; set; }

    }
}
