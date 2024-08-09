using Spectre.Console;
using TrafficManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;


namespace TrafficManagementSystem { 

   public class Program
    {

        public static void Main()
        {
            //new signal system for junction
            SignalSystem signal = new SignalSystem();

            //new element to display the signal status and menu
            SignalDisplay display = new SignalDisplay();

            int option = 1;
            /*Thread thread = new Thread(() =>
            {   while (option != 4)
                {
                    Console.Clear();
                    display.DrawTable(signal);
                    System.Threading.Thread.Sleep(1000);
                }
            });
            thread.Start();*/
            //UI
            
            while (option != 4)
            {   
                Console.Clear();
                //display table and menu
                display.DrawTable(signal);
                display.DisplayMenu("Automatic");
                Console.Write("Enter option and press enter to change mode : ");
                System.Threading.Thread.Sleep(1000);

                if(option==1)
                {
                    //make changes
                }

                else if (option == 2)
                {
                    Console.Clear();
                    //display table and menu
                    display.DrawTable(signal);
                    display.DisplayMenu("Manual");
                    System.Threading.Thread.Sleep(1000);

                    //call function for maintaining signal manually
                    string action;
                    
                    do
                    {

                        Console.Write("Enter the Lane you want to turn green / Enter the option menu : ");
                        action = Console.ReadLine();

                        if (!action.All(char.IsDigit))
                        {
                            ManualMode.manual(action,signal);
                            Console.WriteLine("Manual Signal Updated");
                        }
                        else
                        {
                            
                            break;
                        }
                        

                       
                        //call the required action
                        Console.Clear();
                        display.DrawTable(signal);
                        display.DisplayMenu("Manual");
                    } while (true);
                    option = Int32.Parse(action);

                    //if(action== "1")
                    //{
                    //    //change back to automatic
                    //}

                    //if(action== "3")
                    //{
                    //    //change to emergency
                    //    Console.WriteLine("You are in Emergency Mode");
                    //}

                    //if(action== "4")
                    //{

                    //}
                    
                }

                else if(option == 3)
                {
                    Console.Clear();
                    //display table and menu
                    display.DrawTable(signal);
                    display.DisplayMenu("Emergency");
                    System.Threading.Thread.Sleep(1000);
                    string emergencylane;
                    do
                    {
                        Console.WriteLine("Choose the Emergency Lane : ");
                        Console.WriteLine("a.A->B");
                        Console.WriteLine("b.A->C");
                        Console.WriteLine("c.A->D");
                        Console.WriteLine("d.B->A");
                        Console.WriteLine("e.B->C");
                        Console.WriteLine("f.B->D");
                        Console.WriteLine("g.C->A");
                        Console.WriteLine("h.C->B");
                        Console.WriteLine("i.C->D");
                        Console.WriteLine("j.D->A");
                        Console.WriteLine("k.D->B");
                        Console.WriteLine("l.D->C");
                        emergencylane = Console.ReadLine();
                        //to store signals status
                        SignalSystem prevsystem = signal;

                        //call necessary function to make it emergency lane

                        //can now restore to prevsystem

                    } while (emergencylane != "1" && emergencylane != "2" && emergencylane != "4");
                    if (emergencylane == "1") 
                    { 
                        //go to automatic mode
                    }

                    if(emergencylane == "2")
                    {
                        //go to manual mode
                    }

                    if (emergencylane == "4")
                    {
                        System.Environment.Exit(1);
                    }
                   


                }

                //option = Convert.ToInt32(Console.ReadLine());
            }

        }    
    }
    
}
