using System;

namespace HabitTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HabitEngine.CreateTable();
            var menu = new Menu();

            while (menu.MenuSelection != Menu.MenuOptions.ExitProgram)
            {
                menu.DisplayMenu();
                menu.GetMenuSelection();
                menu.AccessMenuSelection();
            }
        }
    }
}
