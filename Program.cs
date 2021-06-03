using Newtonsoft.Json;
using practiceAPIOpenWeather.RequestObject;
using practiceAPIOpenWeather.ResponseObject;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceAPIOpenWeather
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Request_CurrentWeather();
        
            string url = String.Format(obj.getWeatherByCityName, "gfdgffdg", "2f45ec1571c6451311ed3c4b5937678b");

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            
            Console.WriteLine("response raw data \r\n" + response.Content.ToString());


            Response_CurrentWeatherData weathrResponse = JsonConvert.DeserializeObject<Response_CurrentWeatherData>(response.Content.ToString());

            if (weathrResponse.message == "city not found")
            {
                Console.WriteLine("cant find city");
            }
            Console.Read();
        }
    }
}
