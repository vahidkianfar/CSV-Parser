using CSV_Parser.Models;
using Spectre.Console;

namespace CSV_Parser.UI;

public static class SearchMenu
{
    public static async Task Start(List<Person> persons)
    {
        
        while (true)
        {
            Console.Clear();
            var selectInstructionOption =
                ConsoleHelper.MultipleChoice(true, "1. Search by First Name and Last Name", "2. Search by County" , "3. Search by Company Name",
                    "4. Retrieve Persons by House Number Digits (3 digits)" , "5. Search by the least URL Characters", "6. Retrieve Persons by Postal Code Digits (1 digits)",
                    "7. Retrieve Persons by bigger first phone number","8. Exit");
            switch (selectInstructionOption)
            {
                case 0:
                    Console.Clear();
                    var firstName = AnsiConsole.Ask<string>("Enter First Name (e.g. [orange1]Karma[/]): ");
                    var lastName = AnsiConsole.Ask<string>("Enter Last Name (e.g. [orange1]Quarto[/]): ");
                    Console.Clear();
                    await Person.RetrievePersonByName(persons, firstName, lastName);
                    PressAnyKeyToContinue();
                    break;
                
                case 1:
                    Console.Clear();
                    var county = AnsiConsole.Ask<string>("Enter the County (e.g. [orange1]Derbyshire[/]): "); ;
                    await Person.RetrievePersonByCounty(persons, county);
                    PressAnyKeyToContinue();
                    break;
                
                case 2:
                    Console.Clear();
                    var company = AnsiConsole.Ask<string>("Enter the Company Name \"Full or Partial\" (e.g. [orange1]Esq[/]): ");
                    await Person.RetrievePersonByCompanyName(persons, company);
                    PressAnyKeyToContinue();
                    break;
                
                case 3:
                    //var houseNumberDigits = AnsiConsole.Ask<int>("Enter the House Number Digits (e.g. [orange1]3[/]): ");
                    Console.Clear();
                    await Person.RetrievePersonByHouseNumberDigits(persons, 3);
                    PressAnyKeyToContinue();
                    break;
                
                case 4:
                    Console.Clear();
                    var urlCharacters = AnsiConsole.Ask<int>("Enter the least URL Characters (e.g. [orange1]35[/]): ");
                    await Person.RetrievePersonByURL(persons, urlCharacters);
                    PressAnyKeyToContinue();
                    break;
                
                case 5:
                    //var postalCodeDigits = AnsiConsole.Ask<int>("Enter the Postal Code Digits (e.g. [orange1]1[/]): ");
                    Console.Clear();
                    await Person.RetrievePersonByPostalCodeNumberOfDigits(persons, 1);
                    
                    PressAnyKeyToContinue();
                    break;
                
                case 6:
                    Console.Clear();
                    await Person.RetrievePersonByBiggerFirstPhoneNumber(persons);
                    PressAnyKeyToContinue();
                    break;
                
                case 7:
                    Environment.Exit(0);
                    break;
            }
        }
    }
    
    private static void PressAnyKeyToContinue()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.ResetColor();
        Console.Clear();
    }
}