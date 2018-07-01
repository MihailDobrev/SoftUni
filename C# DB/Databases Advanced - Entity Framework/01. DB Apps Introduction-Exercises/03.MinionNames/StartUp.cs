namespace _03.MinionNames
{
    using _02.VillainNames;
    using System;
    using System.Data.SqlClient;
    public class StartUp
    {
        public static void Main()
        {
            int searchedVillianId = int.Parse(Console.ReadLine());
            var connection = Configuration.EstablishConnection();

            using (connection)
            {

                string querry = "SELECT Name FROM dbo.Villains " +
                   $"WHERE Id = {searchedVillianId}";

               string villainName = (string)ExecuteQuerry(connection, querry);
                
                if (villainName == null)
                {
                    Console.WriteLine($"No villain with ID {searchedVillianId} exists in the database.");
                    Environment.Exit(0);
                }
                else
                {               
                    Console.WriteLine($"Villain: {villainName}");
                }

                querry = "SELECT COUNT(*) FROM dbo.MinionsVillains AS mv " +
                "INNER JOIN dbo.Minions AS m ON m.Id = mv.MinionId " +
                $"WHERE mv.VillainId = {searchedVillianId}";

                int minionsForSearchedVillianCount = (int)ExecuteQuerry(connection, querry);

                if (minionsForSearchedVillianCount==0)
                {
                    Console.WriteLine("(no minions)");
                }
                else
                {
                    querry = "SELECT m.Name, m.Age FROM dbo.MinionsVillains AS mv " +
                      "INNER JOIN dbo.Minions AS m ON m.Id = mv.MinionId " +
                       $"WHERE VillainId = {searchedVillianId} " +
                      "ORDER BY m.Name";

                    var command = new SqlCommand(querry, connection);

                    var reader = command.ExecuteReader();
                    int counter = 0;

                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        int age = (int)reader["Age"];

                        counter++;
                        Console.WriteLine($"{counter}. {name} {age}");                     
                    }
                }
            }
        }

        private static object ExecuteQuerry(SqlConnection connection, string querry)
        {          
            var command = new SqlCommand(querry, connection);
            return command.ExecuteScalar();           
        }
    }
}
