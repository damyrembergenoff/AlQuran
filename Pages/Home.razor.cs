using AlQuran.Models;
using AlQuran.Services;
using Microsoft.AspNetCore.Components;


namespace AlQuran.Pages;

public partial class Home : ComponentBase
{
    [Inject] SuraService? suraService { get; set; }
    [Inject] OyadService? oyadService { get; set; }
    [Inject] OyadImageService? imageService { get; set; }
    [Inject] OyadAudioService? audioService { get; set; }
    [Inject] OyadTranslation? oyadTranslation { get; set; }

    private Sura selectedSura = null!;
    private List<Sura> suras = new();

    private Oyad selectedOyad = null!;
    private List<Oyad> oyads = new();

    private string imageUrl { get; set; } = "";
    private string audioUrl { get; set; } = "";
    private string OyadTranslationText { get; set; } = "";
    private bool isTranslationShow = false;
    private MudBlazor.Color Color = MudBlazor.Color.Warning;

    protected override async Task OnInitializedAsync()
    {
        suras = await suraService!.GetSurasAsync();
    }

    public async Task OnSuraChanged(Sura newSura)
    {
        selectedSura = newSura;
        oyads = await oyadService?.GetOyadsAsync(newSura.Number)!;
        selectedOyad = null!;
        isTranslationShow = false;
        Color =  MudBlazor.Color.Warning;
        OyadTranslationText = "";
    }

    public async Task OnOyadChanged(Oyad newOyad)
    {
        selectedOyad = newOyad;
        imageUrl = imageService?.GetOyadImage(selectedSura.Number, newOyad.NumberInSurah) ?? "";
        audioUrl = audioService?.GetOyadAudio(newOyad.Number) ?? "";
        await GetTranslationText();
    }

    public async Task GetTranslationText()
    {
        try
        {
            OyadTranslationText = await oyadTranslation!.GetTranslateText(selectedSura.Number, selectedOyad.NumberInSurah);
        }
        catch
        {
            OyadTranslationText = "Текстни олишда серверда хатолик, таржимани очириб ёқинг ва яна ҳаракат қилиб коринг.";
        }
    }

    public async Task ShowTranslationText()
    {
        isTranslationShow = !isTranslationShow;
        Color = isTranslationShow == true ? MudBlazor.Color.Success : MudBlazor.Color.Warning;

        if(isTranslationShow)
        {
            try
            {
                OyadTranslationText = await oyadTranslation!.GetTranslateText(selectedSura.Number, selectedOyad.NumberInSurah);
            }
            catch
            {
                OyadTranslationText = "Текстни олишда серверда хатолик, таржимани очириб ёқинг ва яна ҳаракат қилиб коринг.";
            }
        }
    }
    public async Task SkipToNextAudio()
    {
        if(selectedOyad.NumberInSurah < selectedSura.NumberOfAyahs)
            selectedOyad = oyads.FirstOrDefault(x => x.NumberInSurah == selectedOyad.NumberInSurah + 1)!;
        else
            selectedOyad = oyads.FirstOrDefault(x => x.NumberInSurah == 1)!;

        await OnOyadChanged(selectedOyad);
    }
}