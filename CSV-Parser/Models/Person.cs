using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text.RegularExpressions;
using CSV_Parser.UI;
using Spectre.Console;

namespace CSV_Parser.Models;

public class Person
{
    [Column("first_name")]
    public string FirstName { get; set; }
    
    [Column("last_name")]
    public string LastName { get; set; }
    
    [Column("company_name")]
    public string CompanyName { get; set; }
    
    [Column("address")]
    public string Address { get; set; }
    
    [Column("city")]
    public string City { get; set; }
    
    [Column("county")]
    public string County { get; set; }
    
    [Column("postal")]
    public string Postal { get; set; }
    
    [Column("phone1")]
    public string Phone1 { get; set; }
    
    [Column("phone2")]
    public string Phone2 { get; set; }
    
    [Column("email")]
    public string Email { get; set; }
    
    [Column("web")]
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
        var query = persons.Where(person => person.FirstName == firstName && person.LastName == lastName);
        // var query = from person in persons
        //     where person.FirstName == firstName && person.LastName == lastName
        //     select person;
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
        var queryCounty = persons.Where(person => person.County == county);
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
        var queryCompany = persons.Where(person => person.CompanyName.Contains(company));
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
        
        var queryHouseNumberDigits = persons.Where(person => Regex.IsMatch(person.Address, @"^\b\d{3}\b"));
        //----IF the HouseNumber is #NUMBER------//
        //var queryHouseNumberDigits = persons.Where(person => Regex.IsMatch(person.Address, @"#\d{3}\b"));
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
        var queryURL = persons.Where(person => person.Web.Length > urlCharacters);
        // var queryURL = from person in persons
        //     where person.Web.Length > urlCharacters
        //     select person;
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
        var queryPostalCodeDigits = persons.Where(person => Regex.IsMatch(person.Postal, @"[a-zA-Z]\d{1}\b"));
        // var queryPostalCodeDigits = from person in persons
        //     where Regex.IsMatch(person.Postal, @"[a-zA-Z]\d{1}\b")
        //     select person;
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
        var queryPhoneNumberDigits = persons.Where(person =>
            BigInteger.Parse(person.Phone1.Replace("-", ""))
            .CompareTo(BigInteger.Parse(person.Phone2.Replace("-", ""))) == 1);
        
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