using Models;
using ServiceContracts;

namespace Services
{
    public class WeatherService : IWeatherService
    {
        private readonly List<CityWeather> _cityWeather;
        public WeatherService()
        {
            _cityWeather = new List<CityWeather>() {
                new CityWeather()
                {
                    CityUniqueCode = "LDN",
                    CityName = "London",
                    DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),
                    TemperatureFahrenheit = 33
                },
                new CityWeather(){
                    CityUniqueCode = "NYC",
                    CityName = "London",
                    DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),
                    TemperatureFahrenheit = 60
                },
                new CityWeather()
                {
                    CityUniqueCode = "PAR",
                    CityName = "Paris",
                    DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),
                    TemperatureFahrenheit = 82
                }
            };
        }
        public List<CityWeather> GetWeatherDetails()
        {
            return _cityWeather;
        }
        public CityWeather? GetWeatherByCityCode(string CityCode)
        {
            CityWeather? city = _cityWeather.FirstOrDefault(item => item.CityUniqueCode == CityCode);
            return city;
        }
    }
}