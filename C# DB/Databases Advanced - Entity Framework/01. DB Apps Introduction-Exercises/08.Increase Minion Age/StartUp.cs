namespace _08.Increase_Minion_Age
{
    using _02.VillainNames;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var connection = Configuration.EstablishConnection();
            var command = connection.CreateCommand();
            int[] ids = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
           
            foreach (var id in ids)
            {
                command.CommandText = $"UPDATE Minions SET Age += 1 WHERE Id = {id}";
                command.ExecuteNonQuery();
                command.CommandText = $"UPDATE Minions "+
                                    "SET Name = CONCAT(UPPER(LEFT(Name, 1)), SUBSTRING(Name, 2, LEN(Name) - 1)) "+
                                    $"WHERE Id = {id}";
                command.ExecuteNonQuery();
            }

            command.CommandText = $"SELECT Name, Age FROM Minions";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = (string)reader["Name"];
                int age = (int)reader["Age"];

                Console.WriteLine($"{name} {age}");
            }
        }
    }
}
