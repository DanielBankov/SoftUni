using _01._Initial_Setup;
using System;
using System.Data.SqlClient;

namespace _06._Remove_Villain
{
    public class StartUp
    {
        public static void Main()
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string selectVillainsName = @"SELECT Name FROM Villains WHERE Id = @villainId";

                using(SqlCommand command = new SqlCommand(selectVillainsName, connection))
                {
                    command.Parameters.AddWithValue("@villainId", id);
                    string name = (string)command.ExecuteScalar();
                    
                    if(name == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }

                    Console.WriteLine($"{name} was deleted.");
                }

                string deleteMinionVillain = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";

                using (SqlCommand command = new SqlCommand(deleteMinionVillain, connection))
                {
                    command.Parameters.AddWithValue("@villainId", id);
                    int releasedMinions = command.ExecuteNonQuery();

                    Console.WriteLine($"{releasedMinions} minions were released.");
                }

                string deleteVillain = @"DELETE FROM Villains WHERE Id = @villainId";

                using (SqlCommand command = new SqlCommand(deleteVillain, connection))
                {
                    command.Parameters.AddWithValue("@villainId", id);
                    command.ExecuteNonQuery();
                }

            }
        }
    }
}
