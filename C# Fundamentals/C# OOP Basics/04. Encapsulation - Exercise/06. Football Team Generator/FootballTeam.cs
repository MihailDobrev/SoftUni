namespace _06.Football_Team_Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FootballTeam
    {
        private string name;
        private List<Player> players;

        public FootballTeam(string name)
        {
            this.name = name;
            this.players = new List<Player>();
        }

        public List<Player> Players
        {
            get { return players; }
            private set { players = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public double GetRating()
        {
            double totalAverage = 0;
            foreach (var player in Players)
            {
                totalAverage+= player.Average();
            }
            int totalPlayers = Players.Count;
            totalAverage = totalAverage / totalPlayers;
            if (double.IsNaN(totalAverage))
            {
                return 0;
            }
            else
            {
                return Math.Round(totalAverage, MidpointRounding.AwayFromZero);
            }
          
        }

        public void RemovePlayer(Player player)
        {
            Player searchedPlayer = Players.Where(p => p.Name == player.Name).FirstOrDefault();

            if (searchedPlayer == null)
            {
                throw new ArgumentException($"Player {player.Name} is not in {Name} team. ");
            }
            Players.Remove(searchedPlayer);
        }
    }
}
