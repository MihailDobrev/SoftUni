namespace _04.AddMinion
{
    using _02.VillainNames;
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var connection = Configuration.EstablishConnection();

            string[] minionArgs = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

            string[] villainArgs = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

            string townName = minionArgs[2];
            string villainName = villainArgs[0];

            using (connection)
            {

                string querry = "SELECT Id FROM dbo.Towns " +
                        $"WHERE Name = '{townName}'";

                string townId = Convert.ToString(ExecuteQuerry(connection, querry));

                if (townId == string.Empty)
                {
                    querry = $"INSERT INTO dbo.Towns(Name) VALUES('{townName}')";

                    ExecuteQuerry(connection, querry);

                    querry = "SELECT TOP 1 Id FROM dbo.Towns " +
                        $"ORDER BY Id DESC";

                    townId = Convert.ToString(ExecuteQuerry(connection, querry));

                    Console.WriteLine($"Town {townName} was added to the database.");
                }

                querry = "SELECT Id FROM dbo.Villains " +
                          $"WHERE Name = '{villainName}'";

                string villainIdFound = Convert.ToString(ExecuteQuerry(connection, querry));

                int villainID = 0;

                if (villainIdFound == string.Empty)
                {
                    querry = $"INSERT INTO dbo.Villains(Name, EvilnessFactorId) VALUES ('{villainName}', 4)";

                    ExecuteQuerry(connection, querry);

                    Console.WriteLine($"Villain {villainName} was added to the database.");

                    querry = $"SELECT TOP 1 Id FROM dbo.Villains " +
                          $"ORDER BY Id DESC";

                    ExecuteQuerry(connection, querry);

                    villainID = (int)ExecuteQuerry(connection, querry);
                }
                else
                {
                    villainID = int.Parse(villainIdFound);
                }

                querry = $"INSERT INTO dbo.Minions( Name, Age, TownId ) VALUES('{minionArgs[0]}', {minionArgs[1]}, {int.Parse(townId)})";

                ExecuteQuerry(connection, querry);


                querry = $"SELECT TOP 1 Id FROM dbo.Minions " +
                          $"ORDER BY Id DESC";

                int minionId = (int)ExecuteQuerry(connection, querry);


                querry = $"INSERT INTO dbo.MinionsVillains(MinionId,VillainId) VALUES({minionId}, {villainID})";

                ExecuteQuerry(connection, querry);

                Console.WriteLine($"Successfully added {minionArgs[0]} to be minion of {villainName}");
                
            }
        }

        private static object ExecuteQuerry(SqlConnection connection, string querry)
        {
            var command = new SqlCommand(querry, connection);
            return command.ExecuteScalar();
        }
    }
}
