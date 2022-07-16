using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using System.Numerics;
using System.Text.RegularExpressions;
using CSV_Parser.UI;
using Spectre.Console;

namespace CSV_Parser.Models;

public class Person
{
    [Column("first_name")] public string FirstName { get; set; }
    [Column("last_name")] public string LastName { get; set; }
    [Column("company_name")] public string CompanyName { get; set; }
    [Column("address")] public string Address { get; set; }
    [Column("city")] public string City { get; set; }
    [Column("county")] public string County { get; set; }
    [Column("postal")] public string Postal { get; set; }
    [Column("phone1")] public string Phone1 { get; set; }
    [Column("phone2")] public string Phone2 { get; set; }
    [Column("email")] public string Email { get; set; }
    [Column("web")] public string Web { get; set; }

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
        var query = persons.Where(person =>
            string.Equals(person.FirstName, firstName, StringComparison.CurrentCultureIgnoreCase)
            && string.Equals(person.LastName, lastName, StringComparison.CurrentCultureIgnoreCase));
        
        await PrettyDisplay(query, persons);
        
        // var query =  from person in persons
        //              where person.FirstName == firstName && person.LastName == lastName
        //              select person;
    }

    public static async Task RetrievePersonByCounty(List<Person> persons, string county)
    {
        var queryCounty = persons.Where(person =>
            string.Equals(person.County, county, StringComparison.CurrentCultureIgnoreCase));
        
        await PrettyDisplay(queryCounty, persons);
    }

    public static async Task RetrievePersonByCompanyName(List<Person> persons, string company)
    {
        var queryCompany = persons.Where(person => person.CompanyName.Contains(company));
        await PrettyDisplay(queryCompany, persons);
    }

    public static async Task RetrievePersonByHouseNumberDigits(List<Person> persons, int houseNumberDigits)
    {
        var queryHouseNumberDigits = persons.Where(person => Regex.IsMatch(person.Address, @"^\b\d{3}\b"));
        await PrettyDisplay(queryHouseNumberDigits, persons, true);
        
        //----IF the HouseNumber is after "#" --> #NUMBER------//
        
        //var queryHouseNumberDigits = persons.Where(person => Regex.IsMatch(person.Address, @"#\d{3}\b"));
    }

    public static async Task RetrievePersonByURL(List<Person> persons, int urlCharacters)
    {
        var queryUrl = persons.Where(person => person.Web.Length > urlCharacters);
        await PrettyDisplay(queryUrl, persons, false, true);
    }

    public static async Task RetrievePersonByPostalCodeNumberOfDigits(List<Person> persons, int postalCodeDigits)
    {
        var queryPostalCodeDigits = persons.Where(person => Regex.IsMatch(person.Postal, @"[a-zA-Z]\d{1}\b"));
        await PrettyDisplay(queryPostalCodeDigits, persons, false, false, true);
    }

    public static async Task RetrievePersonByBiggerFirstPhoneNumber(List<Person> persons)
    {
        var queryPhoneNumberDigits = persons.Where(person =>
            BigInteger.Parse(person.Phone1.Replace("-", ""))
                .CompareTo(BigInteger.Parse(person.Phone2.Replace("-", ""))) == 1);
        
        await PrettyDisplay(queryPhoneNumberDigits, persons, false, false, false,true);
        
    }

    private static async Task PrettyDisplay(IEnumerable<Person> query, List<Person> persons, bool address=false , bool url=false, bool postal=false, bool phone=false)
    {
        var enumerable = query.ToList();
        if (enumerable.Count != 0)
        {
            //I Know It's UGLY and BAD, but it works for now.
            if (!address && !url && !postal && !phone)
                await CreateLiveTable.LiveTable(enumerable.Count, enumerable, persons);
            if (address)
                await CreateLiveTable.LiveTable(enumerable.Count, enumerable, persons, true);
            if(url)
                await CreateLiveTable.LiveTable(enumerable.Count, enumerable, persons, false, true);
            if(postal)
                await CreateLiveTable.LiveTable(enumerable.Count, enumerable, persons, false,false, true);
            if(phone)
                await CreateLiveTable.LiveTable(enumerable.Count, enumerable, persons, false,false, false,true);
        }
        
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("No results found");
            Console.ResetColor();
        }
    }
}