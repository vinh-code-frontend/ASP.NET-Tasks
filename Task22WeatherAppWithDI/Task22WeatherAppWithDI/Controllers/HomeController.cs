using Microsoft.AspNetCore.Mvc;
using Models;
using ServiceContracts;

namespace Task22WeatherAppWithDI.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherService;
        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Cities Weather";
            List<CityWeather> weatherList = _weatherService.GetWeatherDetails();
            return View(weatherList);
        }
        [Route("/weather/{cityCode}")]
        public IActionResult WeatherDetails(string? cityCode)
        {
            ViewData["Title"] = "Can't find city";
            if (cityCode == null)
            {
                return View();
            }
            CityWeather? matchingCity = _weatherService.GetWeatherByCityCode(cityCode);
            if (matchingCity != null)
            {
                ViewData["Title"] = $"Weather of {matchingCity.CityName}";
            }
            return View(matchingCity);
        }
    }
}
