using System;

namespace HabitTracker
{
    public class Menu
    {
        public enum MenuOptions
        {
            LogHabit,
            DeleteLog,
            UpdateLog,
            ViewLog,
            ExitProgram,
            InvalidOption
        }

        public MenuOptions MenuSelection { get; private set; }

        public void RunMenu()
        {
            DisplayMenu();
            GetMenuSelection();
            AccessMenuSelection();
        }

        private void DisplayMenu()
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

        private void GetMenuSelection()
        {
            switch (Helpers.GetUserInt())
            {
                case 1:
                    MenuSelection = MenuOptions.LogHabit;
                    break;
                case 2:
                    MenuSelection = MenuOptions.DeleteLog;
                    break;
                case 3:
                    MenuSelection = MenuOptions.UpdateLog;
                    break;
                case 4:
                    MenuSelection = MenuOptions.ViewLog;
                    break;
                case 5:
                    MenuSelection = MenuOptions.ExitProgram;
                    break;
                default:
                    MenuSelection = MenuOptions.InvalidOption;
                    break;
            }
        }

        private void AccessMenuSelection()
        {
            switch (MenuSelection)
            {
                case MenuOptions.LogHabit:
                    HabitEngine.LogHabit();
                    break;
                case MenuOptions.DeleteLog:
                    // HabitEngine.DeleteLog();
                    break;
                case MenuOptions.UpdateLog:
                    // HabitEngine.UpdateLog();
                    break;
                case MenuOptions.ViewLog:
                    HabitEngine.ViewLog();
                    break;
                case MenuOptions.ExitProgram:
                    Console.WriteLine("Exiting Program...");
                    break;
                case MenuOptions.InvalidOption:
                    Console.Clear();
                    Console.WriteLine("Invalid Menu Entry. Press enter to return to menu.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
