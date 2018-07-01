namespace _05.ChangeTownNamesCasing
{
    using _02.VillainNames;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var connection = Configuration.EstablishConnection();

            string countryName = Console.ReadLine();

            using (connection)
            {
                string querry =
                    "SELECT COUNT(*) FROM dbo.Towns AS t " +
                    "JOIN dbo.Countries AS c ON c.Id = t.CountryCode " +
                    $"WHERE c.Name = '{countryName}'";

                SqlCommand command = new SqlCommand(querry, connection);

                int townsForThisCountry = (int)command.ExecuteScalar();

                if (townsForThisCountry == 0)
                {
                    Console.WriteLine("No town names were affected.");
                    Environment.Exit(0);
                }

                querry =
                    "UPDATE dbo.Towns " +
                    "SET Name = UPPER(Name) " +
                    "WHERE Name IN(SELECT t.Name FROM dbo.Towns AS t " +
                    "JOIN dbo.Countries AS c ON c.Id = t.CountryCode " +
                    $"WHERE c.Name = '{countryName}')";

                command = new SqlCommand(querry, connection);

                int rowsAffected = command.ExecuteNonQuery();

                Console.WriteLine($"{rowsAffected} town names were affected. ");

                querry = " SELECT t.Name FROM dbo.Towns AS t " +
                "JOIN dbo.Countries AS c ON c.Id = t.CountryCode " +
                $"WHERE c.Name = '{countryName}'";

                command = new SqlCommand(querry, connection);

                var reader = command.ExecuteReader();

                List<string> towns = new List<string>();

                while (reader.Read())
                {
                    towns.Add((string)reader["Name"]);
                }

                Console.WriteLine(string.Join(", ", towns));
            }
        }
    }
}
