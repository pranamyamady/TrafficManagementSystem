using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Emergency
{
    public class EmergencyState
    {
        public void EmergencyOperation(SignalSystem signal, string lane)
        {
            if (lane == "A")
            {
                signal.a = "Green";
                signal.b = "Red";
                signal.c = "Red";
                signal.d = "Red";
            }
            if (lane == "B")
            {
                signal.a = "Red";
                signal.b = "Green";
                signal.c = "Red";
                signal.d = "Red";
            }
            if (lane == "C")
            {
                signal.a = "Red";
                signal.b = "Red";
                signal.c = "Green";
                signal.d = "Red";
            }
            if (lane == "D")
            {
                signal.a = "Red";
                signal.b = "Red";
                signal.c = "Red";
                signal.d = "Green";
            }
        }
    }
}
