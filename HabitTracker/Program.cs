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
                menu.AccessMenuSelection();
            }
        }
    }
}
