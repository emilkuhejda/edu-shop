using EduShop.Client;
using EduShop.Client.Http;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient(nameof(WebClient), client =>
{
    client.BaseAddress = new Uri("https://localhost:7085");
    client.Timeout = TimeSpan.FromSeconds(10);
});

builder.Services.AddScoped<IWebClient, WebClient>();

await builder.Build().RunAsync();
