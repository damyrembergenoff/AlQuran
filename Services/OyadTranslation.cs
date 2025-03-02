using System.Net.Http.Json;
using AlQuran.Models;

namespace AlQuran.Services;

public class OyadTranslation(HttpClient client)
{
    public async Task<string> GetTranslateText(int surahNumber, int oyadNumber)
    {
        var url = $"https://api.alquran.cloud/v1/ayah/{surahNumber}:{oyadNumber}/uz.sodik";
        var Response = await client.GetFromJsonAsync<OyadTranslationTextResponse>(url);
        return Response?.Data?.Text ?? "Oyadni o'zbek tilidagi tarjimasini olishda muammo";
    }
}