using Spectre.Console;

namespace CSV_Parser.Models;

public class Person
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string CompanyName { get; set; }
    
    public string Address { get; set; }
    
    public string City { get; set; }
    
    public string County { get; set; }
    
    public string Postal { get; set; }
    
    public string Phone1 { get; set; }
    
    public string Phone2 { get; set; }
    
    public string Email { get; set; }
    
    public string Web { get; set; }
    
    public Person(string rowData)
    {
        var columns = rowData.Split(',');
        FirstName = columns[0];
        LastName = columns[1];
        CompanyName = columns[2];
        Address = columns[3];
        City = columns[4];
        County = columns[5];
        Postal = columns[6];
        Phone1 = columns[7];
        Phone2 = columns[8];
        Email = columns[9];
        Web = columns[10];
    }
    public static void RetrievePersonByName(List<Person> persons, string firstName, string lastName)
    {
        Console.Clear();
        
        
        var query = from person in persons
            where person.FirstName.Contains(firstName) && person.LastName.Contains(lastName)
            select person;

        List<Person> enumerablePerson = query.ToList();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Count: " + enumerablePerson.Count);
        Console.ResetColor();
        var counter = 0;
        foreach (var person in enumerablePerson)
        {
            Console.WriteLine(counter+1+ ". " + person.FirstName + " " + person.LastName + " - " + person.CompanyName);
            counter++;
        }
       
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.ResetColor();
    }
    
    public static void RetrievePersonByCounty(List<Person> persons, string county)
    {
        var queryCounty = from person in persons
            where person.County.Contains(county)
            select person;
    
        List<Person> enumerableCounty = queryCounty.ToList();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Count: " + enumerableCounty.Count);
        Console.ResetColor();
        var counter = 0;
        foreach (var person in enumerableCounty)
        {
            Console.WriteLine(counter+1+ ". " + person.FirstName + " " + person.LastName + " - " + person.CompanyName);
            counter++;
        }
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.ResetColor();
    }

}