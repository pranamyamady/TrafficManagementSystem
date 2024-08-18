using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Common;

namespace Automatic
{
    public static class AutomaticMode
    {
        /// <summary>
        /// Resets the timers based on the current active signal
        /// </summary>
        /// <param name="signal">the current state of the signal system</param>
        public static void ResetTime(SignalSystem signal)
        {
            
            if (signal.a == "Green")
            {
                signal.atime = 10;
                signal.btime = 10;
                signal.ctime = 20;
                signal.dtime = 30;
            }
            else if (signal.b == "Green")
            {
                signal.atime = 30;
                signal.btime = 10;
                signal.ctime = 10;
                signal.dtime = 20;
            }
            else if (signal.c == "Green")
            {
                signal.atime = 20;
                signal.btime = 30;
                signal.ctime = 10;
                signal.dtime = 10;
            }
            else if (signal.d == "Green")
            {
                signal.atime = 10;
                signal.btime = 20;
                signal.ctime = 30;
                signal.dtime = 10;
            }
        }

        /// <summary>
        /// automatic signal handler
        /// </summary>
        /// <param name="signal">the current signal status</param>
        /// <returns> the key last pressed</returns>
        public static ConsoleKey AutoSignal(SignalSystem signal)
        {        
            while (true)
            {
                
                //loop decrements timer till timer reaches zero
                while (signal.atime != 0 && signal.btime != 0 && signal.ctime != 0 && signal.dtime != 0)
                {
                    //checks for any interruption
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(true).Key;                        
                        return key;
                    }
                    //goes to sleep for 1s
                    System.Threading.Thread.Sleep(1000);
                    //decrements timers
                    
                    signal.atime = Math.Max(signal.atime - 1, 0);
                    signal.btime = Math.Max(signal.btime - 1, 0);
                    signal.ctime = Math.Max(signal.ctime - 1, 0);
                    signal.dtime = Math.Max(signal.dtime - 1, 0);

                }

                if (signal.a == "Green")
                {   
                    //updates the signals
                    signal.a = "Red";
                    signal.b = "Green";

                }
                else if (signal.b == "Green")
                {
                    //updates the signals
                    signal.b = "Red";
                    signal.c = "Green";

                }
                else if (signal.c == "Green")
                {
                    //updates the signals
                    signal.c = "Red";
                    signal.d = "Green";

                }
                else
                {
                    //updates the signals
                    signal.d = "Red";
                    signal.a = "Green";

                }

                //resets the timers when they reach 0
                ResetTime(signal);
            }
        }
    }
}
