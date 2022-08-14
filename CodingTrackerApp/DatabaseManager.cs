using ConsoleTableExt;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTrackerApp
{
    public static class DatabaseManager
    {
        public static void Read()
        {
            using (var connection = new SqliteConnection(Helper.ConnectionStringValue("constr")))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText =
                    "SELECT * FROM session_table";
                cmd.ExecuteNonQuery();

                SqliteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var dataTable = new List<List<object>>()
                    {
                            new List<object>{ reader["Id"], reader["StartTime"], reader["EndTime"], reader["Duration"] }
                    };
                    ConsoleTableBuilder
                        .From(dataTable)
                        .WithFormat(ConsoleTableBuilderFormat.Alternative)
                        .WithColumn("Id", "Start Time", "End Time", "Duration")
                        .ExportAndWriteLine(TableAligntment.Center);
                }
                connection.Close();
            }
        }

        public static void Create()
        {
            UserInput.GetCreateSartTimeInput();
            UserInput.GetCreateEndTimeInput();
            Helper.DurationCalculator();

            using (var connection = new SqliteConnection(Helper.ConnectionStringValue("constr")))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText =
                    @$"INSERT INTO session_table(StartTime, EndTime, Duration) VALUES(
                    '{Convert.ToString(CodingSession.StartTime)}', 
                    '{Convert.ToString(CodingSession.EndTime)}', 
                    '{Convert.ToString(CodingSession.Duration)}')";
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void Update()
        {
            Read();
            UserInput.GetUpdateInput();
            Helper.DurationCalculator();

            using (var connection = new SqliteConnection(Helper.ConnectionStringValue("constr")))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText =
                    $@"UPDATE session_table
                        SET StartTime = '{CodingSession.StartTime}', EndTime = '{CodingSession.EndTime}', Duration = '{CodingSession.Duration}'
                        WHERE Id = '{CodingSession.Id}'";
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void Delete()
        {
            Read();
            UserInput.GetDeleteInput();

            using (var connection = new SqliteConnection(Helper.ConnectionStringValue("constr")))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText =
                    $"DELETE FROM session_table WHERE Id = '{CodingSession.Id}'";
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
