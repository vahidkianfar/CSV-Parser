using CSV_Parser.Models;
using Spectre.Console;

namespace CSV_Parser.UI;

public static class CreateLiveTable
{
    public static async Task LiveTable(int personCounter, List<Person> persons, bool address=false, bool url=false, bool postal=false, bool phone=false)
    {
        Console.Clear();
        var table = new Table().LeftAligned().BorderColor(Color.Blue);
        await AnsiConsole.Live(table)
            .AutoClear(false)
            .StartAsync(ctx =>
            {
                table.AddColumn("");
                table.AddColumn("First Name");
                table.AddColumn("Last Name");
                table.AddColumn("Company Name");
                
                if(address) table.AddColumn("Address");
                if(url) table.AddColumn("URL");
                if(postal) table.AddColumn("Postal Code");
                
                if (phone)
                {
                    table.AddColumn("Phone1");
                    table.AddColumn("Phone2");
                }
                
                for (var row = 0; row <personCounter; row++)
                {
                    table.AddRow($"{row+1}");
                }
                
                var counter = 0;
                while(counter<personCounter)
                {
                    foreach (var person in persons)
                    {
                        table.UpdateCell(counter, 1, $"[yellow]{person.FirstName}[/]");
                        table.UpdateCell(counter, 2, $"[yellow]{person.LastName}[/]");
                        table.UpdateCell(counter, 3, $"[yellow]{person.CompanyName}[/]");
                        if (address)
                            table.UpdateCell(counter, 4, $"[yellow]{person.Address}[/]");
                        if (url)
                            table.UpdateCell(counter, 4, $"[yellow]{person.Web}[/]");
                        if (postal)
                            table.UpdateCell(counter, 4, $"[yellow]{person.Postal}[/]");
                        if (phone)
                        {
                            table.UpdateCell(counter, 4, $"[yellow]{person.Phone1}[/]");
                            table.UpdateCell(counter, 5, $"[yellow]{person.Phone2}[/]");
                        }
                        
                        counter++;
                    }
                    ctx.Refresh();
                    counter++;
                }
                return Task.CompletedTask;
            });
    }
}