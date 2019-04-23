using _01._Initial_Setup;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _07._Print_All_Minion_Names
{
    public class StartUo
    {
        public static void Main()
        {
            List<string> names = new List<string>();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string cmdText = "SELECT Name FROM Minions";

                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            names.Add((string)reader[0]);
                        }
                    }
                }
            }

            names = new List<string>();
            names.Add("1");
            names.Add("2");
            names.Add("3");
            names.Add("4");
            names.Add("5");


            for (int i = 0; i < names.Count / 2; i++)
            {
                Console.WriteLine(names[i]);
                Console.WriteLine(names[names.Count - 1 - i]);
            }

            if(names.Count % 2 != 0)
            {
                Console.WriteLine(names[names.Count / 2]);
            }
        }
    }
}
