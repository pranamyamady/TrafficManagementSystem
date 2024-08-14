using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem;
using Common;
using Automatic;
using Manual;

namespace TrafficManagementSystem
{
    public static class Menu
    {   

        /// <summary>
        /// provides switch case to choose from menu
        /// </summary>
        /// <param name="key"></param>
        /// <param name="signal"></param>
        public static void TakeAction(ConsoleKey key, SignalSystem signal)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                    //--------- AUTOMATIC MODE ----------------
                    //erase previous line
                    Miscellaneous.ErasePreviousLine();
                    AnsiConsole.MarkupLine("[green]MODE : AUTOMATIC                     [/]");
                    //calls the automatic handler and returns the key that interuppted the automation of the signal
                    key = AutomaticMode.AutoSignal(signal);
                    break;



                case ConsoleKey.D2:
                    //--------- MANUAL MODE ----------------
                    //erase previous line
                    Miscellaneous.ErasePreviousLine();
                    AnsiConsole.MarkupLine("[green]MODE : MANUAL                        [/]");
                    AnsiConsole.MarkupLine("Choose the signal you want to turn green  :                                                           ");
                    key = Console.ReadKey(true).Key;
                    // loop that asks for the signal to be changed
                    while (key == ConsoleKey.A || key == ConsoleKey.B || key == ConsoleKey.C || key == ConsoleKey.D)
                    {   //calls the manual signal handler
                        ManualMode.manual(key.ToString(), signal);
                        //erase previous line
                        Miscellaneous.ErasePreviousLine();                   
                        AnsiConsole.MarkupLine("Signal " + key.ToString() + " updated!                                                      ");
                        AnsiConsole.MarkupLine("Choose the signal you want to turn green  :                                                       ");
                        key = Console.ReadKey(true).Key;
                    }
                    break;



                case ConsoleKey.D3:
                    //--------- EMERGENCY MODE ----------------
                    //erase previous line
                    Miscellaneous.ErasePreviousLine();
                    AnsiConsole.MarkupLine("[green]MODE : EMERGENCY                     [/]");
                    AnsiConsole.MarkupLine("Choose the signal you want to turn green  :                                                  ");
                    key = Console.ReadKey(true).Key;
                    // loop that asks for the signal to be changed
                    while (key == ConsoleKey.A || key == ConsoleKey.B || key == ConsoleKey.C || key == ConsoleKey.D)
                    {
                        //emergency mode handler is called
                        ManualMode.manual(key.ToString(), signal);
                        //erase previous line
                        Miscellaneous.ErasePreviousLine();
                        AnsiConsole.MarkupLine("Signal " + key.ToString() + " cleared !                                                 ");
                        AnsiConsole.MarkupLine("Choose the signal you want to turn green (A/B/C/D) :                                             ");
                        key = Console.ReadKey(true).Key;
                    }
                    break;

                case ConsoleKey.D4:
                    //----------------- Reset Signal --------------------
                    AnsiConsole.MarkupLine("Signals reset complete!                                                                      ");
                    System.Threading.Thread.Sleep(1000);
                    signal.Reset();
                    break;



                case ConsoleKey.Escape: 
                    //-------------------- EXIT ----------------
                    System.Environment.Exit(1); 
                    break;

            }
        }
    }
}
