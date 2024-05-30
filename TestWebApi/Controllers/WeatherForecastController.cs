using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using TestWebApi;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly WeatherDB _context;

    public WeatherForecastController(WeatherDB context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetAll")]
    public IEnumerable<WeatherForecast> Get()
    {
        return _context.WeatherForecasts.ToList();
    }

    [HttpGet("{id}")]

    public IActionResult GetById([FromRoute] int id)
    {
        var Weather = _context.WeatherForecasts.Find(id);
        if (Weather == null)
        {
            return NotFound();
        }
        return Ok(Weather);
    }


    public class WeatherForecastInputModel
{
    public int AddDays { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
}

[HttpPost]
public async Task<IActionResult> Post([FromBody] WeatherForecastInputModel input)
{
    var weather = new WeatherForecast
    {
        Date = DateTime.Now.AddDays(input.AddDays),
        TemperatureC = input.TemperatureC,
        Summary = input.Summary
    };

    _context.WeatherForecasts.Add(weather);
    await _context.SaveChangesAsync();

    return Ok(weather);
}

    [HttpPut("{id}")]
    public async Task<IActionResult> PutById([FromRoute] int id, [FromBody] WeatherForecast Weather)
    {
        if (id != Weather.Id)
        {
            return BadRequest();
        }

        _context.Entry(Weather).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            return Ok(Weather);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.WeatherForecasts.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById([FromRoute] int id)
    {
        var weatherForecast = await _context.WeatherForecasts.FindAsync(id);
        if (weatherForecast == null)
        {
            return NotFound();
        }

        _context.WeatherForecasts.Remove(weatherForecast);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}