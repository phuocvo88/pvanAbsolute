using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceAPIOpenWeather.RequestObject
{
    public class Request_CurrentWeather
    {
        public string getWeatherByCityName = "http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}";
        public string getWeatherByCityNameAndStateCode = "http://api.openweathermap.org/data/2.5/weather?q={0},{1}&appid={2}";
        public string getWeatherByCityNameAndStateCodeAndCountryCode = "http://api.openweathermap.org/data/2.5/weather?q={0},{1},{2}&appid={3}";

        public string getWeatherByLatLong = "http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid={2}";
    }
}
