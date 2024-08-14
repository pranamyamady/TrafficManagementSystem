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
            signal.ChangeSignal(s);
            signal.atime = signal.btime = signal.ctime = signal.dtime = 0;
        }
    }
}
