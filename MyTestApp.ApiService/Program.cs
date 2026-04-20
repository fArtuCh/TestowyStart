using Microsoft.EntityFrameworkCore;
using MyTestApp.ApiService.Data;
using MyTestApp.ApiService.Models;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();

builder.AddNpgsqlDbContext<AppDbContext>("testdb");

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

await using (var scope = app.Services.CreateAsyncScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.EnsureCreatedAsync();
}

string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

app.MapGet("/", () => "API service is running. Navigate to /weatherforecast to see sample data.");

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/wpisy", async (AppDbContext db) =>
    await db.Wpisy.OrderByDescending(w => w.DataDodania).ToListAsync());

app.MapPost("/wpisy", async (WpisDto dto, AppDbContext db) =>
{
    var wpis = new Wpis { Tresc = dto.Tresc, DataDodania = DateTime.UtcNow };
    db.Wpisy.Add(wpis);
    await db.SaveChangesAsync();
    return Results.Created($"/wpisy/{wpis.Id}", wpis);
});

app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

record WpisDto(string Tresc);
