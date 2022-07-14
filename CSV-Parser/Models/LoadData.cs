namespace CSV_Parser.Models;

public static class LoadData
{
    private static readonly  DirectoryInfo? DatasetPath =
        Directory.GetParent(Directory.GetParent(
            Directory.GetParent(
                Directory.GetParent(
                        Directory.GetCurrentDirectory())?
                    .ToString() ?? string.Empty)?.ToString()
            ?? string.Empty)?.ToString() ?? string.Empty);
    public static List<Person> FromCsv()
    {
        var Text = File.ReadAllLines(DatasetPath + "/CSV-Parser/Dataset/input.csv");
        var Persons = Text.Select(line => new Person(line)).ToList();
        return Persons;
    }
}