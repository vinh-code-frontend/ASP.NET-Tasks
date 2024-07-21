using Microsoft.AspNetCore.Mvc;
using Task14WeatherApp.Models;

namespace Task14WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private List<CityWeather> cityWeathers = new List<CityWeather>()
        {
            new CityWeather ()
            {
               CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),  TemperatureFahrenheit = 33
            },
            new CityWeather ()
            {
                CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  TemperatureFahrenheit = 60
            },
            new CityWeather()
            {
                CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  TemperatureFahrenheit = 82
            }
        };
        [Route("/")]
        public IActionResult Index()
        {
            return View(cityWeathers);
        }
        [Route("/weather/{cityCode?}")]
        public IActionResult CityWeather(string? cityCode)
        {
            ViewData["Title"] = "Can't find city";
            if (cityCode == null)
            {
                return View();
            }
            CityWeather? matchingCity = cityWeathers.Where(city => city.CityUniqueCode == cityCode).FirstOrDefault();
            if (matchingCity != null)
            {
                ViewData["Title"] = $"Weather of {matchingCity.CityName}";
            }
            return View(matchingCity);
        }
    }
}