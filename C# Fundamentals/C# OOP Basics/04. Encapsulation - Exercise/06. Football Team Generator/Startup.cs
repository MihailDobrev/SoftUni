namespace _06.Football_Team_Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<FootballTeam> teams = new List<FootballTeam>();

            while (input != "END")
            {
                string[] inputArgs = input
               .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                int argsCount = inputArgs.Length;
                string command = inputArgs[0];

                try
                {
                    switch (argsCount)
                    {
                        case 2:
                            switch (command.ToLower())
                            {
                                case "team":
                                    FootballTeam team = new FootballTeam(inputArgs[1]);
                                    teams.Add(team);
                                    break;
                                case "rating":
                                    string teamName = inputArgs[1];
                                    FootballTeam searchedTeam = teams.Where(t => t.Name == teamName).FirstOrDefault();
                                    if (searchedTeam == null)
                                    {
                                        throw new ArgumentException($"Team {inputArgs[1]} does not exist.");
                                    }
                                    Console.WriteLine($"{searchedTeam.Name} - {searchedTeam.GetRating()}");
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 3:

                            if (command == "Remove")
                            {
                                FootballTeam ft = teams.Where(t => t.Name == inputArgs[1]).FirstOrDefault();
                                if (ft == null)
                                {
                                    throw new ArgumentException($"Team {inputArgs[1]} does not exist.");
                                }
                                Player searchedPlayer = ft.Players.Where(p => p.Name == inputArgs[2]).FirstOrDefault();
                                if (searchedPlayer == null)
                                {
                                    throw new ArgumentException($"Player {inputArgs[2]} is not in {inputArgs[1]} team.");
                                }

                                ft.RemovePlayer(searchedPlayer);
                            }
                            break;
                        case 8:
                            if (command == "Add")
                            {
                                FootballTeam searched = teams.Where(t => t.Name == inputArgs[1]).FirstOrDefault();
                                if (searched == null)
                                {
                                    throw new ArgumentException($"Team {inputArgs[1]} does not exist.");
                                }
                                short endurance = short.Parse(inputArgs[3]);
                                short sprint = short.Parse(inputArgs[4]);
                                short dribble = short.Parse(inputArgs[5]);
                                short passing = short.Parse(inputArgs[6]);
                                short shooting = short.Parse(inputArgs[7]);
                                Player player = new Player(inputArgs[2], endurance, sprint, dribble, passing, shooting);
                                searched.AddPlayer(player);
                            }
                            else if (command == "Remove")
                            {
                                FootballTeam ft = teams.Where(t => t.Name == inputArgs[1]).FirstOrDefault();
                                if (ft == null)
                                {
                                    throw new ArgumentException($"Team {inputArgs[1]} does not exist.");
                                }
                                Player searchedPlayer = ft.Players.Where(p => p.Name == inputArgs[2]).FirstOrDefault();
                                if (searchedPlayer == null)
                                {
                                    throw new ArgumentException($"Player {inputArgs[2]} is not in {inputArgs[1]} team.");
                                }

                                ft.RemovePlayer(searchedPlayer);

                            }

                            break;
                        default:
                            break;
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                input = Console.ReadLine();
            }


        }
    }
}
