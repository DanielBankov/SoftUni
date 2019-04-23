﻿using System;
using System.Data.SqlClient;
using System.Text;
using _01._Initial_Setup;

namespace _02._Villain_Names
{
    public class StartUp
    {
        public static void Main()
        {
            StringBuilder sb = new StringBuilder();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string sqlQuery = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                     FROM Villains AS v
                                     JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                 GROUP BY v.Id, v.Name
                                   HAVING COUNT(mv.VillainId) > 3
                                 ORDER BY COUNT(mv.VillainId)";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int count = (int)reader[1];

                            sb.AppendLine($"{name} - {count}");
                        }
                    }
                }
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
