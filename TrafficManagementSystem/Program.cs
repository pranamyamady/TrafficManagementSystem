using Spectre.Console;
using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using TrafficManagementSystem;
using Common;
using Automatic;
using Manual;



class Program
{   //key to handle user inputs
    public static ConsoleKey key;
    //flag for the intial default mode
    public static int flag = 0;
    static async Task Main(string[] args)
    {           
        //new signal system for junction
        SignalSystem signal = new SignalSystem();
        
        //Table for display
        var table = new Table()
            .AddColumn("[blue]Signal[/]")
            .AddColumn("[blue]Status[/]")
            .AddColumn("[blue]Time Left[/]");

        var cts = new CancellationTokenSource();

        // Start the table update task
        var tableTask = Task.Run(async () =>
        {
            await AnsiConsole.Live(table)
                .StartAsync(async ctx =>
                {
                    
                    while(true)
                    {
                        table.Rows.Clear(); // Clear previous rows
                        //display table
                        if (signal.mode=="Automatic")
                        {
                            table.AddRow("A", signal.a, signal.atime.ToString());
                            table.AddRow("B", signal.b, signal.btime.ToString());
                            table.AddRow("C", signal.c, signal.ctime.ToString());
                            table.AddRow("D", signal.d, signal.dtime.ToString());
                        }
                        else//hides time left for automatic and emergency modes
                        {
                            table.AddRow("A", signal.a, " - ");
                            table.AddRow("B", signal.b, " - ");
                            table.AddRow("C", signal.c, " - ");
                            table.AddRow("D", signal.d, " - ");
                        }
                        table.Border(TableBorder.Rounded);
                        table.Centered();
                        //refreshes the page
                        ctx.Refresh();
                        // Wait for 1 second
                        await Task.Delay(1000); 
                    }                    
                });
        }, cts.Token);

       
        // Start the user input task
        var inputTask = Task.Run(() =>
        {
            while (!cts.Token.IsCancellationRequested)
            {
                Console.Clear();                
                AnsiConsole.MarkupLine("[underline green][bold][italic]TRAFFIC MANAGEMENT SYSTEM[/][/][/]");
                AnsiConsole.MarkupLine("                                                                                             ");
                AnsiConsole.MarkupLine("[green]Menu :                                                                                                             [/]");
                AnsiConsole.MarkupLine("[red]1. Automatic                                                                                                         [/]");
                AnsiConsole.MarkupLine("[red]2. Manual                                                                                                            [/]");
                AnsiConsole.MarkupLine("[red]3. Emergency                                                                                                         [/]");
                AnsiConsole.MarkupLine("[red]4. Reset                                                                                                             [/]");
                AnsiConsole.MarkupLine("[red]5. Exit                                                                                                             [/]");
                AnsiConsole.MarkupLine("[green]MODE : AUTOMATIC                                                                                                   [/]");
                //by default automatic is called
                if (flag == 0)
                {
                    signal.ChooseMode(ConsoleKey.D1); flag = 1;
                }
                switch (signal.mode)
                {
                    case "Automatic":
                        //--------- AUTOMATIC MODE ----------------
                        //erase previous line
                        Miscellaneous.ErasePreviousLine();
                        AnsiConsole.MarkupLine("[green]MODE : AUTOMATIC                     [/]");
                        //calls the automatic handler and returns the key that interuppted the automation of the signal                       
                        key =AutomaticMode.AutoSignal(signal);                       
                        break;



                    case "Manual":
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



                    case "Emergency":
                        //--------- EMERGENCY MODE ----------------
                        //erase previous line
                        SignalSystem oldsignal= new SignalSystem();
                        oldsignal.mode = signal.mode;
                        oldsignal.a= signal.a;
                        oldsignal.b= signal.b;
                        oldsignal.c= signal.c;                            
                        oldsignal.d= signal.d;
                        oldsignal.atime= signal.atime;
                        oldsignal.btime= signal.btime;
                        oldsignal.ctime= signal.ctime; 
                        oldsignal.dtime= signal.dtime;
                         
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
                        signal.mode = oldsignal.mode;
                        signal.a = oldsignal.a;
                        signal.b = oldsignal.b;
                        signal.c = oldsignal.c;
                        signal.d = oldsignal.d;
                        signal.atime = oldsignal.atime;
                        signal.btime = oldsignal.btime;
                        signal.ctime = oldsignal.ctime;
                        signal.dtime = oldsignal.dtime;
                        break;

                    case "Reset":
                        //----------------- Reset Signal --------------------
                        AnsiConsole.MarkupLine("Signals reset complete!                                                                      ");
                        System.Threading.Thread.Sleep(1000);
                        signal.Reset();
                        //takes in input
                        key= Console.ReadKey(true).Key;
                        break;



                    case "Exit":
                        //-------------------- EXIT ----------------
                        System.Environment.Exit(1);
                        break;

                    

                }
                //update mode
                signal.ChooseMode(key);              
            }
        }, cts.Token);

        // Wait for the table task to complete
        await tableTask;

        // Cancel the input task
        cts.Cancel();
        await inputTask;
    }
}