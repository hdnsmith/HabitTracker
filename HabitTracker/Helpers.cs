using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker
{
    internal class Helpers
    {
        internal static int GetUserInt()
        {
            string? input;
            int output;

            input = Console.ReadLine();

            if (int.TryParse(input, out output))
            {
                return output;
            }

            return -1;
        }
    }
}
