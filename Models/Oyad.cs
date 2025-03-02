namespace AlQuran.Models;

public class OyadResponse
{
    public Data? Data { get; set; }
}

public class Data
{
    public List<Oyad>? Ayahs { get; set; }
}

public class Oyad
{
    public int Number { get; set; }
    public int NumberInSurah { get; set; }
}