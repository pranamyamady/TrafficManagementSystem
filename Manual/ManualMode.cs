using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Manual
{
    public class ManualMode
    {


        /// <summary>
        /// changes signal manually
        /// </summary>
        /// <param name="s"></param>
        /// <param name="signal"></param>
        public static void manual(string s, SignalSystem signal)
        {
            if (s == "A")
            {
                signal.a = "Green";
                signal.b = "Red";
                signal.c = "Red";
                signal.d = "Red";
            }
            else if (s == "B")
            {
                signal.a = "Red";
                signal.b = "Green";
                signal.c = "Red";
                signal.d = "Red";
            }

            else if (s == "C")
            {
                signal.a = "Red";
                signal.b = "Red";
                signal.c = "Green";
                signal.d = "Red";
            }
            else
            {
                signal.a = "Red";
                signal.b = "Red";
                signal.c = "Red";
                signal.d = "Green";
            }
        }
    }
}
