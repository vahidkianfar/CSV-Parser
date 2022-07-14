using CSV_Parser.Models;
using Spectre.Console;

namespace CSV_Parser.UI;

public static class SearchMenu
{
    public static void Start(List<Person> persons)
    {
        
        while (true)
        {
            Console.Clear();
            var selectInstructionOption =
                ConsoleHelper.MultipleChoice(true, "1. Search by First Name and Last Name", "2. Search by County");
            switch (selectInstructionOption)
            {
                case 0:
                    var firstName = AnsiConsole.Ask<string>("Enter First Name (e.g. [orange1]Karma[/]): ");
                    var lastName = AnsiConsole.Ask<string>("Enter Last Name (e.g. [orange1]Quarto[/]): ");
                    Console.Clear();
                    Person.RetrievePersonByName(persons, firstName, lastName);
                    break;
                case 1:
                    var county = AnsiConsole.Ask<string>("Enter the County (e.g. [orange1]Derbyshire[/]): ");
                    Console.Clear();
                    Person.RetrievePersonByCounty(persons, county);
                    
                    break;
                
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }

    }
}