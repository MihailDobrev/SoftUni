
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void AddPlayer(Person player)
        {
            if (player.Age<40)
            {
                firstTeam.Add(player);
                
            }
            else
            {
                reserveTeam.Add(player);
            }
        }
        public IReadOnlyCollection<Person> FirstTeam
        {
            get { return this.firstTeam.AsReadOnly(); }
        }

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return this.reserveTeam.AsReadOnly(); }
        }

        public string ShowAllPlayers()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"First team have {this.FirstTeam.Count()} players {Environment.NewLine}");
            sb.Append($"Reserve team have {this.ReserveTeam.Count()} players");

            return sb.ToString();
        }
    }

