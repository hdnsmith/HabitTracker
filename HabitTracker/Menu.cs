using System;

namespace HabitTracker
{
    internal class Menu
    {
        internal int MenuSelection { get; set; }

        internal void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("MAIN MENU\r\n-----------------------------------" +
                "\r\nWhat would you like to do?" +
                "\r\n\r\n\t1. Log habit" +
                "\r\n\t2. Delete log" +
                "\r\n\t3. Update log" +
                "\r\n\t4. View all logs" +
                "\r\n\t5. Exit application" +
                "\r\n-----------------------------------");
        }

        internal void GetMenuSelection()
        {
            MenuSelection = Helpers.GetUserInt();
        }
    }
}
