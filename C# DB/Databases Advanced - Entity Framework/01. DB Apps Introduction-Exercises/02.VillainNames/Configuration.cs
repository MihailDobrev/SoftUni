using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace _02.VillainNames
{
    public class Configuration
    {
        public static SqlConnection EstablishConnection()
        {
            var connectionString =
                @"Server=(localdb)\MSSQLLocalDB;" +
                @"Database=MinionsDb;" +
                @"Integrated Security=True";

            var connection = new SqlConnection(connectionString);

            connection.Open();
            return connection;
        }
    }
}
