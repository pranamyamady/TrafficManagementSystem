using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Common
{
    public class SignalSystem
    {
        //indicates whether each light is Red/Green
        public string a, b, c, d;

        //time left on each signal to change to Green/Red
        public int atime, btime, ctime, dtime;

        //String indicating which mode they system is in: MANUAL/AUTO/EMERGENCY
        public string mode;

        //constructor
        public SignalSystem()
        {   //by default,A is Green and mode is automatic
            a = "Green";
            b = "Red";
            c = "Red";
            d = "Red";
            atime = 10;
            btime = 10;
            ctime = 20;
            dtime = 30;
            mode = "Automatic";

        }
        /// <summary>
        /// Chooses the mode of the signal based on current keyboard input
        /// </summary>
        /// <param name="key">the input by user</param>
        public void ChooseMode(ConsoleKey key)
        {
            if (key == ConsoleKey.D1) mode = "Automatic";
            else if (key == ConsoleKey.D2) mode = "Manual";
            else if (key == ConsoleKey.D3) mode = "Emergency";
            else if (key == ConsoleKey.D4) mode = "Reset";
            else if (key == ConsoleKey.D5) mode = "Exit";

            
        }
        /// <summary>
        /// changes the signal corresponding to the input
        /// </summary>
        /// <param name="signal">the signal in the system to be changed(A/B/C/D)</param>
        public void ChangeSignal(string signal)
        {
            switch (signal)
            {
                case "A":
                    this.a = "Green";
                    this.b = this.c = this.d = "Red";
                    break;
                case "B":
                    this.b = "Green";
                    this.a = this.c = this.d = "Red";
                    break;
                case "C":
                    this.c = "Green";
                    this.b = this.a = this.d = "Red";
                    break;
                case "D":
                    this.d = "Green";
                    this.b = this.c = this.a = "Red";
                    break;
                default:
                    this.a = this.b = this.c = this.d = "Red";
                    break;
            }
        }

        /// <summary>
        /// option to reset the timers and signals to default
        /// </summary>
        public void Reset()
        {   //by default, A is green
            a = "Green";
            b = "Red";
            c = "Red";
            d = "Red";
            atime = 10;
            btime = 10;
            ctime = 20;
            dtime = 30;
        }




    }
}
