namespace AlQuran.Models;

public class SuraResponse
{
    public List<Sura>? Data { get; set; }
}

public class Sura
{
    public int Number { get; set; }
    public string? EnglishName { get; set; }
    public int NumberOfAyahs { get; set; }
}
