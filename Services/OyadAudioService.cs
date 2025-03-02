namespace AlQuran.Services;

public class OyadAudioService
{
    public string GetOyadAudio(int oyadNumber)
    {
        var audioUrl = $"https://cdn.islamic.network/quran/audio/64/ar.alafasy/{oyadNumber}.mp3";
        return audioUrl;
    }
}