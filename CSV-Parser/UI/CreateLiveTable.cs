using CSV_Parser.Models;
using Spectre.Console;

namespace CSV_Parser.UI;

public static class CreateLiveTable
{
    public static async Task LiveTable(int personCounter, List<Person> persons)
    {
        Console.Clear();
        var table = new Table().LeftAligned().BorderColor(Color.Blue);
        var delayTable = 0;
        await AnsiConsole.Live(table)
            .AutoClear(false)
            .StartAsync(async ctx =>
            {
                table.AddColumn("");
                table.AddColumn("First Name");
                table.AddColumn("Last Name");
                table.AddColumn("Company Name");
        
        
                for (var row = 0; row <personCounter; row++)
                {
                    table.AddRow($"{row+1}");
                    ctx.Refresh();
                    await Task.Delay(delayTable);
                }
                var counter = 0;
                while(counter<personCounter)
                {
                    foreach (var person in persons)
                    {
                        table.UpdateCell(counter, 1, $"[yellow]{person.FirstName}[/]");
                        table.UpdateCell(counter, 2, $"[yellow]{person.LastName}[/]");
                        table.UpdateCell(counter, 3, $"[yellow]{person.CompanyName}[/]");
                        counter++;
                    }
                    ctx.Refresh();
                    counter++;
                }
            });
    }
}