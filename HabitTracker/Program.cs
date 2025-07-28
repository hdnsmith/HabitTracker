using System;

namespace HabitTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HabitEngine.CreateTable();
            var menu = new Menu();

            while (menu.MenuSelection != Menu.MenuOptions.ExitProgram)
            {
                menu.RunMenu();
            }
        }
    }
}
