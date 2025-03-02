using System.Net.Http.Json;
using AlQuran.Models;

namespace AlQuran.Services;

public class OyadService(HttpClient httpClient)
{
    public async Task<List<Oyad>> GetOyadsAsync(int surahNumber)
    {
        var url = $"https://api.alquran.cloud/v1/surah/{surahNumber}/en.asad";
        var Response = await httpClient.GetFromJsonAsync<OyadResponse>(url);
        return Response?.Data?.Ayahs ?? [];
    }

}