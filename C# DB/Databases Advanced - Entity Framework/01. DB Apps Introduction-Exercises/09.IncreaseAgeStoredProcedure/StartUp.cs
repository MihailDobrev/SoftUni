namespace _09.IncreaseAgeStoredProcedure
{
    using _02.VillainNames;
    using System;
    using System.Data;

    public class StartUp
    {
        public static void Main()
        {
            var connection = Configuration.EstablishConnection();

            var command = connection.CreateCommand();

            // We create the following procedure using Management Studio:
            //
            // CREATE PROC usp_GetOlder (@MinionId INT)
            // AS
            //    UPDATE Minions
            //    SET Age += 1
            //    WHERE Id = @MinionId
            //    
            //    SELECT Name, Age FROM Minions
            //    WHERE Id = @MinionId
         

            command.CommandText = "usp_GetOlder";
            command.CommandType = CommandType.StoredProcedure;

            int minionId = int.Parse(Console.ReadLine());
            command.Parameters.AddWithValue("@MinionId", minionId);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = (string)reader["Name"];
                int age = (int)reader["Age"];

                Console.WriteLine($"{name} – {age} years old");
            }

        }
    }
}
