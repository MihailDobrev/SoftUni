namespace _06.RemoveVillain
{
    using _02.VillainNames;
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            var connection = Configuration.EstablishConnection();

            int searchedVillainId = int.Parse(Console.ReadLine());
            SqlTransaction transaction = connection.BeginTransaction();

            SqlCommand command = connection.CreateCommand();

            command.Transaction = transaction;

            try
            {
                string villainName = FindVillainName(searchedVillainId, command);

                if (villainName == null)
                {
                    Console.WriteLine("No such villain was found.");
                    Environment.Exit(0);
                }

                int minionsCount = GetMinionsCount(searchedVillainId, command);

                string minionsReleased = string.Empty;

                if (minionsCount == 0)
                {
                    minionsReleased = "0 minions were released.";
                }
                else
                {
                    command.CommandText = $"DELETE FROM MinionsVillains WHERE VillainId = {searchedVillainId}";

                    int minionsDeleted = (int)command.ExecuteNonQuery();

                    minionsReleased = $"{minionsDeleted} minions were released.";
                }

                DeleteVillain(searchedVillainId, command);

                transaction.Commit();

                PrintResult(villainName, minionsReleased);
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
       
        }

        private static void DeleteVillain(int searchedVillainId, SqlCommand command)
        {
            command.CommandText = $"DELETE FROM Villains WHERE Id = {searchedVillainId}";

            command.ExecuteNonQuery();
        }

        private static int GetMinionsCount(int searchedVillainId, SqlCommand command)
        {
            command.CommandText = " SELECT COUNT(*) FROM MinionsVillains AS mv " +
                                    "JOIN Minions AS m ON m.Id = mv.MinionId " +
                                    $"WHERE VillainId = {searchedVillainId}";

            int minionsCount = (int)command.ExecuteScalar();
            return minionsCount;
        }

        private static string FindVillainName(int searchedVillainId, SqlCommand command)
        {
            command.CommandText = $"SELECT Name FROM Villains WHERE Id = {searchedVillainId}";

            string villainName = (string)command.ExecuteScalar();
            return villainName;
        }

        private static void PrintResult(string villainName, string minionsReleased)
        {
            Console.WriteLine($"{villainName} was deleted.");
            Console.WriteLine(minionsReleased);
        }
    }
}
