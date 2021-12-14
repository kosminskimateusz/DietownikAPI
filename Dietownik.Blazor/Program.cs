using Dietownik.Blazor;
using Dietownik.Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.AddHttpClient();

builder.Services.AddScoped(sp => 
new HttpClient 
{ 
    BaseAddress = new Uri("https://localhost:44371") 
});

await builder.Build().RunAsync();
