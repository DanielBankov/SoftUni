using System;
using System.Data.SqlClient;

using _01._Initial_Setup;

namespace _09._Increase_Age_Stored_Proc
{
    public class StartUp
    {
        public static void Main()
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string proc = @"EXEC usp_GetOlder @id";

                using (SqlCommand command = new SqlCommand(proc, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        string name = (string)reader[0];
                        int age = (int)reader[1];

                        Console.WriteLine($"{name} {age}");
                    }
                }
            }
        }
    }
}
