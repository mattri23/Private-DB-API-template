using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestWebApi;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Weather") ?? "Data Source=WeatherForecast.db";

// Add services to the container.

builder.Services.AddSqlite<WeatherDB>(connectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the authorization services
builder.Services.AddAuthorization();

// Add the controllers services
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

/*app.MapGet("/Weather", async (WeatherDB db) => await db.WeatherForecasts.ToListAsync());
app.MapPost("/Weather", async (WeatherDB db, WeatherForecast Weather) =>
{
    await db.WeatherForecasts.AddAsync(Weather);
    await db.SaveChangesAsync();
    return Results.Created($"/Weather/{Weather.TemperatureC}", Weather);
});

app.MapGet("/Weather/{id}", async (WeatherDB db, int id) => await db.WeatherForecasts.FindAsync(id));

app.MapPut("/Weather/{id}", async (WeatherDB db, WeatherForecast updatepizza, int id) =>
{
      var pizza = await db.WeatherForecasts.FindAsync(id);
      if (pizza is null) return Results.NotFound();
      pizza.TemperatureC = updatepizza.TemperatureC;
      await db.SaveChangesAsync();
      return Results.NoContent();
});
app.MapDelete("/Weather/{id}", async (WeatherDB db, int id) =>
{
   var pizza = await db.WeatherForecasts.FindAsync(id);
   if (pizza is null)
   {
      return Results.NotFound();
   }
   db.WeatherForecasts.Remove(pizza);
   await db.SaveChangesAsync();
   return Results.Ok();
});*/

app.Run();