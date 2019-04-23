using _01._Initial_Setup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace _05._Change_Town_Names_Casing
{
    public class StartUp
    {
        public static void Main()
        {
            string countryName = Console.ReadLine();
            List<string> countries = new List<string>();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string updateTownsCount = @"UPDATE Towns
                                 SET Name = UPPER(Name)
                               WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

                using (SqlCommand command = new SqlCommand(updateTownsCount, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);

                    int count = command.ExecuteNonQuery();

                    if (count == 0)
                    {
                        Console.WriteLine("No town names were affected.");
                        return;
                    }

                    Console.WriteLine($"{count} town names were affected.");
                }

                string selectCountries = @" SELECT t.Name 
                                              FROM Towns as t
                                              JOIN Countries AS c ON c.Id = t.CountryCode
                                             WHERE c.Name = @countryName";

                using (SqlCommand command = new SqlCommand(selectCountries, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            countries.Add((string)reader[0]);
                        }
                    }

                    Console.WriteLine('[' + string.Join(", ", countries) + ']');
                }
            }
        }
    }
}