//include packages
using Spectre.Console;
using TrafficManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficManagementSystem
{
    internal class SignalDisplay
    {
        public void DrawTable(SignalSystem signal)
        {
            var table = new Table();

           //2 columns
            table.AddColumn("Signal Name ");
            table.AddColumn("Red/Green ");
            table.AddColumn("Time left ");

            // one row each for each traffic signal
            table.AddRow("A", signal.a,signal.atime.ToString());
            table.AddRow("B", signal.b, signal.btime.ToString());
            table.AddRow("C", signal.c, signal.ctime.ToString());
            table.AddRow("D", signal.d, signal.dtime.ToString());


            // Render the table to the console
            AnsiConsole.Write(table);
           
        }
        public void DisplayMenu(string mode)
        {
            Console.WriteLine("Traffic Management System !");
            Console.WriteLine("Menu : ");
            Console.WriteLine("1. Automatic(by default)\n2. Manual\n3. Emergency\n4. Exit");
            Console.WriteLine("");
            Console.WriteLine("Current mode : " + mode);
            
        }



    }
}
