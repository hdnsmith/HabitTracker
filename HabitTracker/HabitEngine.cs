using Microsoft.Data.Sqlite;

namespace HabitTracker
{
    static internal class HabitEngine
    {
        internal static void CreateTable()
        {
            using (var connection = new SqliteConnection(@"Data Source=HabitTracker.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS habit (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        date TEXT NOT NULL,
                        quantity INTEGER NOT NULL
                    );";
                command.ExecuteNonQuery();

            }
        }
    }
}
