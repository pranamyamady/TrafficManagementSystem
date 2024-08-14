using Spectre.Console;
using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using TrafficManagementSystem;
using Common;
using Automatic;
class Program
{   
    static async Task Main(string[] args)
    {   //key to choose options
        ConsoleKey key=ConsoleKey.D1;
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
                        //if (key == ConsoleKey.D1)
                        {
                            table.AddRow("A", signal.a, signal.atime.ToString());
                            table.AddRow("B", signal.b, signal.btime.ToString());
                            table.AddRow("C", signal.c, signal.ctime.ToString());
                            table.AddRow("D", signal.d, signal.dtime.ToString());
                        }
                      /*  else//hides time left for automatic and emergency modes
                        {
                            table.AddRow("A", signal.a, " - ");
                            table.AddRow("B", signal.b, " - ");
                            table.AddRow("C", signal.c, " - ");
                            table.AddRow("D", signal.d, " - ");
                        }*/
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
                //tried figlet lol
                //AnsiConsole.Write(new FigletText("Traffic Management System").Centered().Color(Color.Red));
                AnsiConsole.MarkupLine("[underline green][bold][italic]TRAFFIC MANAGEMENT SYSTEM[/][/][/]");
                AnsiConsole.MarkupLine("                                                                                             ");
                AnsiConsole.MarkupLine("[green]Menu :                                                                                                             [/]");
                AnsiConsole.MarkupLine("[red]1. Automatic                                                                                                         [/]");
                AnsiConsole.MarkupLine("[red]2. Manual                                                                                                            [/]");
                AnsiConsole.MarkupLine("[red]3. Emergency                                                                                                         [/]");
                AnsiConsole.MarkupLine("[red]4. Reset                                                                                                             [/]");
                AnsiConsole.MarkupLine("[green]MODE : AUTOMATIC                                                                                                   [/]");

                //by default automatic is called
                key = AutomaticMode.AutoSignal(signal);
                //Menu handler is called
                Menu.TakeAction(key, signal);
              
            }
        }, cts.Token);

        // Wait for the table task to complete
        await tableTask;

        // Cancel the input task
        cts.Cancel();
        await inputTask;
    }
}