using Microsoft.Data.Sqlite;
using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Insert();
        }

        public static void Insert()
        {
            try
            {
                SQLitePCL.Batteries_V2.Init();
                using (var connection = new SqliteConnection("Data Source=123.db"))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
        CREATE TABLE IF NOT EXISTS Tracker (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            TrackerId TEXT,
            TrackerName TEXT,
            TrackerType TEXT
        );
        INSERT INTO Tracker (TrackerId, TrackerName, TrackerType)
        VALUES ('1', '2', 'str')";
                    var result = command.ExecuteNonQuery();

                    Console.WriteLine("result = {0}", result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
