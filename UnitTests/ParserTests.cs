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
    
    [SetUp]
    public void Setup()
    {

    
    }

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
        var persons = Text.Select(line => new Person(line)).ToList();
        persons.Should().NotBeEmpty();
    }
    
    
}