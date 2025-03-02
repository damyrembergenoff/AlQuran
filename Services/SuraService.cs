using System.Net.Http.Json;
using AlQuran.Models;

namespace AlQuran.Services;

public class SuraService(HttpClient httpClient)
{
    public async Task<List<Sura>> GetSurasAsync()
    {
        var url = "https://api.alquran.cloud/v1/surah";
        var response = await httpClient.GetFromJsonAsync<SuraResponse>(url);
        return response?.Data ?? [];
    }

}