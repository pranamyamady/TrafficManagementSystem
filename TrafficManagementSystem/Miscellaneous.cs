using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficManagementSystem
{
    public static class Miscellaneous
    {   
        
        /// <summary>
        /// to erase the previous line
        /// </summary>
        public static void ErasePreviousLine()
        {   //go to previous line
            Console.SetCursorPosition(0, Console.CursorTop - 1);

            // Erase the previous line
            Console.Write(new string(' ', Console.WindowWidth));

            // Move cursor back to the beginning of the current line
            Console.SetCursorPosition(0, Console.CursorTop);
        }



    }
}
