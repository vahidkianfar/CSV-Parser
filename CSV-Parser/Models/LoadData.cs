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
        var text = File.ReadAllLines(DatasetPath + "/CSV-Parser/Dataset/input.csv");
        var persons = text.Select(line => new Person(line)).ToList();
        persons = persons.Skip(1).ToList();
        return persons;
    }

}