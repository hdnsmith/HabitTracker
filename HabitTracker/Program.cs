using System;

namespace HabitTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HabitEngine.CreateTable();

            var menu = new Menu();
            while (menu.MenuSelection != 5)
            {
                menu.DisplayMenu();
                menu.GetMenuSelection();
                switch (menu.MenuSelection)
                {
                    case 1:
                        // HabitEngine.LogHabit();
                        break;
                    case 2:
                        // HabitEngine.DeleteLog();
                        break;
                    case 3:
                        // HabitEngine.UpdateLog();
                        break;
                    case 4:
                        // HabitEngine.ViewLog();
                        break;
                    case 5:
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Menu Entry. Press enter to return to menu.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
