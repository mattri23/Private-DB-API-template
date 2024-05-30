using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace TestWebApi
{
    public class WeatherForecast
    {

        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public class WeatherDB : DbContext
    {
        public WeatherDB(DbContextOptions<WeatherDB> options) : base(options){ }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}