using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
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
    [TestFixture]
    public class TestOpenWeatherEndPoint
    {
       

        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void TestInvalidCityName()
        {
            var requestObj = new Request_CurrentWeather();

            string url = String.Format(requestObj.getWeatherByCityName, "gfdgffdg", "2f45ec1571c6451311ed3c4b5937678b");

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            Console.WriteLine("response raw data \r\n" + response.Content.ToString());

            Response_CurrentWeatherData weathrResponse = JsonConvert.DeserializeObject<Response_CurrentWeatherData>(response.Content.ToString());

            Assert.IsTrue(weathrResponse.message == "city not found");

            //if (weathrResponse.message == "city not found")
            //{
            //    Console.WriteLine("cant find city");
            //}
            //Console.Read();
        }


        [Test]
        public void TestValidCityName()
        {
            var requestObj = new Request_CurrentWeather();

            string url = String.Format(requestObj.getWeatherByCityName, "Ha Noi", "2f45ec1571c6451311ed3c4b5937678b");

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            Console.WriteLine("response raw data \r\n" + response.Content.ToString());

            Response_CurrentWeatherData weathrResponse = JsonConvert.DeserializeObject<Response_CurrentWeatherData>(response.Content.ToString());
            bool validation = false;

            if (weathrResponse.cod == 200 && weathrResponse.name == "Hanoi")
            {
                validation = true;
            }

            Assert.IsTrue(validation);

        }

        [Test]
        public void TestValidLatLong()
        {
            var requestObj = new Request_CurrentWeather();

            string url = String.Format(requestObj.getWeatherByLatLong, "21.0245", "105.841", "2f45ec1571c6451311ed3c4b5937678b");

            Console.WriteLine("url = " + url);

            //throw new Exception();
            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            Console.WriteLine("response raw data \r\n" + response.Content.ToString());

            Response_CurrentWeatherData weathrResponse = JsonConvert.DeserializeObject<Response_CurrentWeatherData>(response.Content.ToString());
            bool validation = false;

            if (weathrResponse.cod == 200 && weathrResponse.name == "Hanoi")
            {
                validation = true;
            }

            Assert.IsTrue(validation);

        }
        [TestCase("Ha Noi", "2f45ec1571c6451311ed3c4b5937678b", "Hanoi")]
        [TestCase("London", "2f45ec1571c6451311ed3c4b5937678b", "London")]
        [Test]
        public void TestValidCityNameWithDataDriven(string cityName, string apiKey, string expectedResult)
        {
            var requestObj = new Request_CurrentWeather();

            string url = String.Format(requestObj.getWeatherByCityName, cityName, apiKey);

            Console.WriteLine("url = " + url);
            //throw new Exception();

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            Console.WriteLine("response raw data \r\n" + response.Content.ToString());

            Response_CurrentWeatherData weathrResponse = JsonConvert.DeserializeObject<Response_CurrentWeatherData>(response.Content.ToString());
            bool validation = false;

            if (weathrResponse.cod == 200 && weathrResponse.name == expectedResult)
            {
                validation = true;
            }

            Assert.IsTrue(validation);

        }

        [TearDown]
        public void Teardown()
        {

        }

    }
}
