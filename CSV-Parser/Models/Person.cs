using System.Numerics;
using System.Text.RegularExpressions;
using CSV_Parser.UI;
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
        var columns = Regex.Split(rowData, "[,]{1}(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
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
    public static async Task RetrievePersonByName(List<Person> persons, string firstName, string lastName)
    {
        var query = from person in persons
            where person.FirstName == firstName && person.LastName == lastName
            select person;
        
        List<Person> enumerablePerson = query.ToList();

        if (enumerablePerson.Count != 0)
        {
            await CreateLiveTable.LiveTable(enumerablePerson.Count, enumerablePerson);
        }

        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("No results found");
            Console.ResetColor();
        }
    }
    
    public static async Task RetrievePersonByCounty(List<Person> persons, string county)
    {
        var queryCounty = from person in persons
            where person.County == county
            select person;
    
        List<Person> enumerableCounty = queryCounty.ToList();
        if (enumerableCounty.Count != 0)
        {
            await CreateLiveTable.LiveTable(enumerableCounty.Count, enumerableCounty);
        }

        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("No results found");
            Console.ResetColor();
        }
    }
    
    public static async Task RetrievePersonByCompanyName(List<Person> persons, string company)
    {
        var queryCompany = from person in persons
            where person.CompanyName.Contains(company)
            select person;

        List<Person> enumerableCompany = queryCompany.ToList();
        if (enumerableCompany.Count != 0)
        {
            await CreateLiveTable.LiveTable(enumerableCompany.Count, enumerableCompany);
        }
        
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("No results found");
            Console.ResetColor();
        }
    }

    public static async Task RetrievePersonByHouseNumberDigits(List<Person> persons, int houseNumberDigits)
    {
        // var queryHouseNumberDigits = from person in persons
        //     where Regex.IsMatch(person.Address, @"#\d{3}\b")
        //     select person;

        var queryHouseNumberDigits = from person in persons
            where Regex.IsMatch(person.Address, @"^\b\d{3}\b")
            select person;

        List<Person> enumerableCompany = queryHouseNumberDigits.ToList();
        
        if (enumerableCompany.Count != 0)
        {
            await CreateLiveTable.LiveTable(enumerableCompany.Count, enumerableCompany, true);
        }
        
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("No results found");
            Console.ResetColor();
        }
        
    }
    
    public static async Task RetrievePersonByURL(List<Person> persons, int urlCharacters)
    {
        var queryURL = from person in persons
            where person.Web.Length > urlCharacters
            select person;

        List<Person> enumerableURL = queryURL.ToList();
        
        if (enumerableURL.Count != 0)
        {
            await CreateLiveTable.LiveTable(enumerableURL.Count, enumerableURL,false,true);
        }
        
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("No results found");
            Console.ResetColor();
        }
    }
    
    public static async Task RetrievePersonByPostalCodeNumberOfDigits(List<Person> persons, int postalCodeDigits)
    {
        var queryPostalCodeDigits = from person in persons
            where Regex.IsMatch(person.Postal, @"[a-zA-Z]\d{1}\b")
            select person;
        
        List<Person> enumerablePostalCodeDigits = queryPostalCodeDigits.ToList();
        
        if (enumerablePostalCodeDigits.Count != 0)
        {
            await CreateLiveTable.LiveTable(enumerablePostalCodeDigits.Count, enumerablePostalCodeDigits, false,false, true );
        }
        
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("No results found");
            Console.ResetColor();
        }
    }
    
    public static async Task RetrievePersonByBiggerFirstPhoneNumber(List<Person> persons)
    {
        var queryPhoneNumberDigits = from person in persons
            where BigInteger.Parse(person.Phone1.Replace("-",""))
                .CompareTo(BigInteger.Parse(person.Phone2.Replace("-",""))) == 1
            select person;
        
        List<Person> enumerablePhoneNumberDigits = queryPhoneNumberDigits.ToList();
        
        if (enumerablePhoneNumberDigits.Count != 0)
        {
            await CreateLiveTable.LiveTable(enumerablePhoneNumberDigits.Count, enumerablePhoneNumberDigits, false,false, false, true);
        }
        
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("No results found");
            Console.ResetColor();
        }
    }
}