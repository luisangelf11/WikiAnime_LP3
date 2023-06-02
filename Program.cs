using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using WikiAnime.Data;
using WikiAnime.Data.Context;
using WikiAnime.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<WikiAnimeDbContext>();
builder.Services.AddScoped<IWikiAnimeDbContext, WikiAnimeDbContext>();
builder.Services.AddScoped<IAnimeServices, AnimeServices>();
builder.Services.AddScoped<IPersonajeServices, PersonajeServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
