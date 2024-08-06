using Spectre.Console;
using TrafficManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TrafficManagementSystem
{
   public class SignalSystem
    {   
        //indicates whether each light is Red/Green
        public string a,b,c,d;

        //time left on each signal to change to Green/Red
        public int atime, btime, ctime, dtime;

        //constructor
       public  SignalSystem()
        {   //by default, a-c is open
            a = "Green";
            b = "Red";
            c = "Green";
            d = "Red";
            atime = 30;
            btime = 30;
            ctime = 30;
            dtime = 30;
        }

        //changes A signal
        public void ChangeASignal(string to)
        {
            if (to == "Green")
            {
                a = "Green";
            }
            else a = "Red";

        }

        //changes B Signal
        public void ChangeBSignal(string to)
        {
            if (to == "Green")
            {
                b = "Green";
            }
            else b = "Red";

        }
        
        //changes C Signal
        public void ChangeCSignal(string to)
        {
            if (to == "Green")
            {
                c = "Green";
            }
            else c = "Red";

        }

        //changes D Signal
        public void ChangeDSignal(string to)
        {
            if (to == "Green")
            {
                d = "Green";
            }
            else d = "Red";

        }

        //option to reset 
        public void Reset()
        {   //by default, a-c is open
            a = "Green";
            b = "Red";
            c = "Green";
            d = "Red";
            atime = 30;
            btime = 30;
            ctime = 30;
            dtime = 30; 
        }



    }
}
