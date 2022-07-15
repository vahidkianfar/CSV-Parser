using CSV_Parser.Models;
using Spectre.Console;

namespace CSV_Parser.UI;

public static class MainMenu
{
    public static async Task Start(List<Person> persons)
    {
        AnsiConsole.Progress()
            .Start(ctx => 
            {
                var task1 = ctx.AddTask("[blue]Loading[/]");
                while(!ctx.IsFinished)
                    task1.Increment(0.00007);
            });
        while (true)
        {
            Console.Clear();
            var selectInstructionOption =
                ConsoleHelper.MultipleChoice(true, "1. Search", "2. Exit");
            switch (selectInstructionOption)
            {
                case 0:
                    await SearchMenu.Start(persons);
                    break;
                
                case 1:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}