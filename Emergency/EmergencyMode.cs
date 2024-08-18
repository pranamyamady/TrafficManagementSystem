using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Emergency
{
    //Handles the emergency situation
    public class EmergencyState
    {
        /// <summary>
        /// sets the current emergency lane based on input
        /// </summary>
        /// <param name="signal">the current signal status</param>
        /// <param name="lane">the input lane to be changed</param>
        public void EmergencyOperation(SignalSystem signal, string lane)
        {   //uses the inbuilt SignalSystem method
           signal.ChangeSignal(lane);
        }
    }
}
