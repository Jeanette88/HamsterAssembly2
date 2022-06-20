using HamsterAssembly2.Client;
using HamsterAssembly2.Client.Services.BattleService;
using HamsterAssembly2.Client.Services.HamsterService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IHamsterService, HamsterService>();
builder.Services.AddScoped<IBattleService, BattleService>();


await builder.Build().RunAsync();
