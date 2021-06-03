using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceAPIOpenWeather.ResponseObject
{
    public class Response_CurrentWeatherData
    {
        public Coord coord { get; set; }
        public Weather[] weather { get; set; }
        public string baseAtt { get; set; }
        public int visibility { get; set; }
        public long dt { get; set; }
        public int timezone { get; set; }
        public long id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
        public MainAtt main { get; set; }
        public string message { get; set; }
        public Sys sys { get; set; }




    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }

    }

    public class Weather
    {
        public string id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    public class MainAtt
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
    }
    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }

    }

    public class Clouds
    {
        public int all { get; set; }

    }
    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public long sunrise { get; set; }
        public long sunset { get; set; }
        public double deg { get; set; }
    }

}
