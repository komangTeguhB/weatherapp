using Microsoft.AspNetCore.Mvc;
using weatherapp.Models;

namespace weatherapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : ControllerBase
    {
        private static readonly object[] CountryCities = new Cities[]
        {
            new Cities { Country = "Indonesia", City = new[] {"Denpasar", "Badung", "Tabanan", "Negara", "Ubud", "Singaraja", "Karangasem"} },
            new Cities { Country = "Brazil", City = new[] { "São Paulo", "Rio de Janeiro", "Brasília", "Salvador", "Fortaleza", "Manaus" } },
            new Cities { Country = "England", City = new[] { "Manchester", "Norwich", "Birmingham", "Bradford", "Brighton & Hove", "Bristol", "Cambridge", "Dunfermline", "Gloucester", "Leeds", "Leicester", "Liverpool" } }
        }
        ;

        private readonly ILogger<CitiesController> _logger;

        public CitiesController(ILogger<CitiesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Cities> Get([FromQuery]string country)
        {
            Cities[] countryCities = (Cities[])CountryCities;

            try
            {
                var result = countryCities.Where(c => c.Country.ToUpper().Contains(country.ToUpper())).ToList();
                return result.ToArray();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}