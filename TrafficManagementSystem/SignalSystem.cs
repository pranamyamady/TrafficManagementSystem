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

        //changes a signal 
        // param: signal A/B/C/D
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
