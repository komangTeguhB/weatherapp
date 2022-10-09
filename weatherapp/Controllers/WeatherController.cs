using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using weatherapp.Models;

namespace weatherapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController
    {
        private static readonly object[] WeatherCities = new Weather[]
        {
            new Weather { 
                Location = "Denpasar",
                Wind = "3.6",
                Visibility = "9.0",
                SkyCondition = "Patchy rain possible",
                TemperatureC = "30.8",
                TemperatureF = "87.4",
                RelativeHumidity = "75",
                Pressure = "1009.0",
            },
            new Weather {
                Location = "Singaraja",
                Wind = "3.6",
                Visibility = "9.0",
                SkyCondition = "Light rain shower",
                TemperatureC = "30.8",
                TemperatureF = "87.4",
                RelativeHumidity = "75",
                Pressure = "1009.0",
            },
            new Weather {
                Location = "Karangasem",
                Wind = "3.6",
                Visibility = "9.0",
                SkyCondition = "Partly cloudy",
                TemperatureC = "30.8",
                TemperatureF = "87.4",
                RelativeHumidity = "75",
                Pressure = "1009.0",
            },
             new Weather {
                Location = "Negara",
                Wind = "3.6",
                Visibility = "9.0",
                SkyCondition = "Sunny",
                TemperatureC = "30.8",
                TemperatureF = "87.4",
                RelativeHumidity = "75",
                Pressure = "1009.0",
            },
             new Weather {
                Location = "Badung",
                Wind = "10.1",
                Visibility = "9.0",
                SkyCondition = "Partly cloudy",
                TemperatureC = "29.1",
                TemperatureF = "84.4",
                RelativeHumidity = "77",
                Pressure = "1009.0",
            },

        }
        ;

        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Weather> Get([FromQuery] string city)
        {
            Weather[] weatherCities = (Weather[])WeatherCities;

            try
            {
                var result = weatherCities.Where(c => c.Location.ToUpper().Contains(city.ToUpper())).ToList();
                return result.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
        }
    }
}
