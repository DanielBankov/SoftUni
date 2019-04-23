using System;
using System.Data.SqlClient;

using _01._Initial_Setup;

namespace _04._Add_Minion
{
    public class StartUp
    {
        public static void Main()
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string[] minionInfo = Console.ReadLine().Split();

                string minionName = minionInfo[1];
                int age = int.Parse(minionInfo[2]);
                string townName = minionInfo[3];

                int? townId = SelectTownId(connection, townName);

                if (townId == null)
                {
                    AddTown(connection, townName);
                    townId = SelectTownId(connection, townName);
                }


                string[] villainInfo = Console.ReadLine().Split();
                string villainName = villainInfo[1];

                int? villainId = SelectVillainId(connection, villainName);

                if (villainId == null)
                {
                    AddVillain(connection, villainName);
                    villainId = SelectVillainId(connection, villainName);
                }

                AddMinion(connection, minionName, age, townId);

                int minionId = SelectMinionId(connection, minionName);

                InsertIntoMinionsVillains(connection, minionId, villainId);

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }

        private static void InsertIntoMinionsVillains(SqlConnection connection, int minionId, int? villainId)
        {
            string insertIntoMappingTable = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

            using (SqlCommand command = new SqlCommand(insertIntoMappingTable, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.Parameters.AddWithValue("@minionId", minionId);
                command.ExecuteNonQuery();
            }
        }

        private static int SelectMinionId(SqlConnection connection, string minionName)
        {
            string selectMinionId = @"SELECT Id FROM Minions WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(selectMinionId, connection))
            {
                command.Parameters.AddWithValue("@Name", minionName);
                return (int)command.ExecuteScalar();
            }
        }

        private static void AddMinion(SqlConnection connection, string minionName, int age, int? townId)
        {
            string addMinion = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

            using (SqlCommand command = new SqlCommand(addMinion, connection))
            {
                command.Parameters.AddWithValue("@name", minionName);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@townId", townId);

                command.ExecuteScalar();
            }
        }

        private static void AddVillain(SqlConnection connection, string villainName)
        {
            string addVillain = @"INSERT INTO Villains (Name, EvilnessFactorId) VALUES (@VallainName, 4)";

            using (SqlCommand command = new SqlCommand(addVillain, connection))
            {
                command.Parameters.AddWithValue("@VallainName", villainName);
                command.ExecuteScalar();

                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
        }

        private static int? SelectVillainId(SqlConnection connection, string villainName)
        {
            string selectVilianId = @"SELECT Id FROM Villains WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(selectVilianId, connection))
            {
                command.Parameters.AddWithValue("@Name", villainName);
                return (int?)command.ExecuteScalar();
            }
        }

        private static int? SelectTownId(SqlConnection connection, string townName)
        {
            string selectTownId = @"SELECT Id FROM Towns WHERE Name = @townName";

            using (SqlCommand command = new SqlCommand(selectTownId, connection))
            {
                command.Parameters.AddWithValue("@townName", townName);
                return (int?)command.ExecuteScalar();
            }
        }

        private static void AddTown(SqlConnection connection, string townName)
        {
            string insertTown = @"INSERT INTO Towns (Name) VALUES (@townName)";

            using (SqlCommand command = new SqlCommand(insertTown, connection))
            {
                command.Parameters.AddWithValue("@townName", townName);
                command.ExecuteScalar();

                Console.WriteLine($"Town {townName} was added to the database.");
            }
        }
    }
}
