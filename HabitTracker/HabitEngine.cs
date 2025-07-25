using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Globalization;

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
                    @"
                    CREATE TABLE IF NOT EXISTS habit (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        date TEXT NOT NULL,
                        quantity INTEGER NOT NULL
                    );";
                command.ExecuteNonQuery();

            }
        }

        internal static void LogHabit()
        {
            Console.Clear();

            string date = GetHabitDate();
            int quantity = GetHabitQuantity();

            using (var connection = new SqliteConnection(@"Data Source=HabitTracker.db"))
            {
                connection.Open();
                
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                    INSERT INTO habit (date, quantity)
                    VALUES ($date, $quantity);
                    ";
                command.Parameters.AddWithValue("$date", date);
                command.Parameters.AddWithValue("$quantity", quantity);
                command.ExecuteNonQuery();
            }
        }

        private static string GetHabitDate()
        {
            Console.Write("Please enter date (YYYY-MM-DD): ");
            string? date = Console.ReadLine();

            while (!DateTime.TryParseExact(date, "yyyy-MM-dd", new CultureInfo("en-US"), DateTimeStyles.None, out _))
            {
                Console.Write("Invalid date.\nPlease enter a numerical date in the correct format (YYYY-MM-DD): ");
                date = Console.ReadLine();
            }

            return date;
        }

        private static int GetHabitQuantity()
        {
            Console.Write("Please enter a numeric quantity (no decimals allowed): ");
            int quantity = Helpers.GetUserInt();

            while (quantity == -1)
            {
                Console.Write("Invalid input.\nPlease enter a numeric quantity (no decimals allowed): ");
                quantity = Helpers.GetUserInt();
            }

            return quantity;
        }
    }

    internal class Habit
    {
        internal int Id { get; set; }
        internal DateTime Date { get; set; }
        internal int Quantity { get; set; }
    }
}
