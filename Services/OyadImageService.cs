namespace AlQuran.Services;

public class OyadImageService
{
    public string GetOyadImage(int surahNumber,int oyadNumber)
    {
        var url = $"https://cdn.islamic.network/quran/images/high-resolution/{surahNumber}_{oyadNumber}.png";
        return url;
    }
}