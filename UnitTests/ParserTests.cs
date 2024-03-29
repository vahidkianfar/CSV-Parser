using CSV_Parser.Models;
using FluentAssertions;
namespace UnitTests;

public class Tests
{
    private static readonly DirectoryInfo? DatasetPath =
        Directory.GetParent(Directory.GetParent(
            Directory.GetParent(
                Directory.GetParent(
                    Directory.GetCurrentDirectory())?
                    .ToString() ?? string.Empty)?.ToString()
            ?? string.Empty)?.ToString() ?? string.Empty);

    private static readonly string[] Text = File.ReadAllLines(DatasetPath + "/CSV-Parser/Dataset/input.csv");
    private static readonly List<Person> Persons = Text.Select(line => new Person(line)).ToList();
    
    [SetUp]
    public void Setup()
    { }
    
    [Test]
    public void Read_Dataset_and_Store_It_Into_String()
    {
        var csvText = File.ReadAllText(DatasetPath + "/CSV-Parser/Dataset/input.csv");
        csvText.Should().NotBeNull();
    }
    
    [Test]
    public void Read_Dataset_and_Store_It_Into_String_And_Check_If_It_Is_Not_Empty()
    {
        var csvText = File.ReadAllText(DatasetPath + "/CSV-Parser/Dataset/input.csv");
        csvText.Should().NotBeEmpty();
    }
    
    [Test]
    public void Create_a_Person_Class_And_Check_If_It_Is_Not_Null_Or_Empty()
    {
        var person = new Person(Text[0]);
        person.Should().NotBeNull();
    }

    [Test]
    public void Store_CSV_File_Into_A_List_Of_Objects_Of_Person_Class()
    {
        Persons.Should().NotBeEmpty();
    }
    
    [Test]
    public void Could_Be_Able_To_Use_Query_To_Find_Specific_Person()
    {
        var query = from person in Persons
            where person.FirstName.Contains("Karma") && person.LastName.Contains("Quarto")
            select person;

        List<Person> enumerable = query.ToList();
        
        enumerable.Count.Should().Be(1);
        Persons.IndexOf(enumerable.First()).Should().Be(30);
        enumerable.First().FirstName.Should().Be("Karma");
        enumerable.First().LastName.Should().Be("Quarto");
        enumerable.First().CompanyName.Should().Be("J C S Machinery");
           
    }
    
    [Test]
    public void Query_For_Company_Name_Should_Return_Correct_Value()
    {
        var company = "Esq";
        
        var queryCompany = from person in Persons
            where person.CompanyName.Contains(company)
            select person;
        
        List<Person> enumerableCompany = queryCompany.ToList();
        
        enumerableCompany.First().FirstName.Should().Be("France");
        enumerableCompany.First().LastName.Should().Be("Andrade");
    }
    
    // [Test]
    // public void RetrievePersonByCounty_Should_Return_Correct_Value()
    // {
    //     var company = "Derbyshire";
    //     
    //     var queryCompany = from person in Persons
    //         where person.CompanyName.Contains(company)
    //         select person;
    //     
    //     List<Person> enumerableCompany = queryCompany.ToList();
    //     
    //     enumerableCompany.First().FirstName.Should().Be("France");
    //     enumerableCompany.First().LastName.Should().Be("Andrade");
    // }
}