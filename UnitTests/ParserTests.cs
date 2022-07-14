using FluentAssertions;
namespace UnitTests;

public class Tests
{
    private static readonly DirectoryInfo? _datasetPath =
        Directory.GetParent(Directory.GetParent(
            Directory.GetParent(
                Directory.GetParent(
                    Directory.GetCurrentDirectory())?
                    .ToString() ?? string.Empty)?.ToString()
            ?? string.Empty)?.ToString() ?? string.Empty);
    
    //string text = File.ReadAllText(_datasetPath + "/CSV-Parser/Dataset/input.csv");
    [SetUp]
    public void Setup()
    {

    
    }

    [Test]
    public void Read_Dataset_and_Store_It_Into_String()
    {
        var text = File.ReadAllText(_datasetPath + "/CSV-Parser/Dataset/input.csv");
        text.Should().NotBeNull();
    }
    
    [Test]
    public void Read_Dataset_and_Store_It_Into_String_And_Check_If_It_Is_Not_Empty()
    {
        var text = File.ReadAllText(_datasetPath + "/CSV-Parser/Dataset/input.csv");
        text.Should().NotBeEmpty();
    }
    
    
}