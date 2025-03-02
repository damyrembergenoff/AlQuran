using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AlQuran;
using MudBlazor.Services;
using AlQuran.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddHttpClient<SuraService>();
builder.Services.AddHttpClient<OyadService>();
builder.Services.AddScoped<OyadImageService>();
builder.Services.AddScoped<OyadAudioService>();
builder.Services.AddScoped<OyadTranslation>();

await builder.Build().RunAsync();