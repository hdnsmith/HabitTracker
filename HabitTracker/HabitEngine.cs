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
                            );
                    ";
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

        internal static void ViewLog()
        {
            Console.Clear();
            Console.WriteLine("Press enter to return to menu.");
            Console.WriteLine("-----------------------------\n");
            DisplayLog();
            Console.WriteLine("\n-----------------------------");
            Console.ReadLine();
        }

        private static void DisplayLog()
        {
            using (var connection = new SqliteConnection(@"Data Source=HabitTracker.db"))
            {
                connection.Open();
                var log = new List<Habit>();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                        SELECT *
                        FROM habit
                    ";

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No logged habits found.");
                        return;
                    }

                    while (reader.Read())
                    {
                        log.Add(
                            new Habit
                            {
                                Id = reader.GetInt32(0),
                                Date = DateTime.ParseExact(reader.GetString(1), "yyyy-MM-dd", new CultureInfo("en-US"), DateTimeStyles.None),
                                Quantity = reader.GetInt32(2)
                            });
                    }

                    foreach (Habit entry in log)
                    {
                        Console.WriteLine($"{entry.Id}\t{entry.Date.ToString("MMMM dd, yyyy")}\t{entry.Quantity}");
                    }
                }

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
