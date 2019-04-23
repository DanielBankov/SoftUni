using System;
using System.Data.SqlClient;

using _01._Initial_Setup;

namespace _03._Minion_Names
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string selectId = @"SELECT Name FROM Villains WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(selectId, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    string villainName = (string)command.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine("No villain with ID 10 exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {villainName}");
                }

                string selectMinions = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                           FROM MinionsVillains AS mv
                                           JOIN Minions As m ON mv.MinionId = m.Id
                                          WHERE mv.VillainId = @Id
                                       ORDER BY m.Name";

                using (SqlCommand command = new SqlCommand(selectMinions, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long rowNum = (long)reader[0];
                            string name = (string)reader[1];
                            int age = (int)reader[2];

                            if (!reader.HasRows)
                            {
                                Console.WriteLine("(no minions)");
                            }

                            Console.WriteLine($"{rowNum}. {name} {age}");
                        }
                    }
                }

            }
        }
    }
}
