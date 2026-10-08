using FQ25L062_Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Nécessite le package nuget Microsoft.Extensions.Http
builder.Services.AddHttpClient(ApiName.DinoManagerApi, options =>
{
    options.BaseAddress = new Uri("https://localhost:7093/");
});
await builder.Build().RunAsync();

static class ApiName
{
    public const string DinoManagerApi = "DinoManagerApi";
}
