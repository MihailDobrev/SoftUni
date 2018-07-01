namespace _07.PrintAllMinionNames
{
    using _02.VillainNames;
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        public static void Main()
        {
            var connection = Configuration.EstablishConnection();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT Name FROM Minions";
            var reader = command.ExecuteReader();

            List<string> names = new List<string>();

            while (reader.Read())
            {
                names.Add((string)reader["Name"]);
            }

            int totalNames = names.Count;

            for (int i = 0; i < totalNames; i++)
            {
                Console.WriteLine(names[0]);
                names.RemoveAt(0);
                names.Reverse();
            }
        }
    }
}
