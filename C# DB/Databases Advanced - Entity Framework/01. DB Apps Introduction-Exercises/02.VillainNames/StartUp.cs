namespace _02.VillainNames
{
    using System;
    using System.Data.SqlClient;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var connection = Configuration.EstablishConnection();

            using (connection)
            {
                string querry = "SELECT v.Name AS Villains, COUNT(mv.MinionId) AS MinionsCount "+
                @"FROM MinionsVillains AS mv "+
                @"INNER JOIN Villains AS v ON v.Id = mv.VillainId "+
                @"GROUP BY v.Name "+
                @"HAVING COUNT(mv.MinionId) > 3";

                SqlCommand command = new SqlCommand(querry,connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var villains = reader["Villains"];
                    var minions = reader["MinionsCount"];
                    Console.WriteLine($"{villains} - {minions}");
                }
            }
        }

      
    }
}
