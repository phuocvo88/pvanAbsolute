using NUnit.Framework;
using practiceAPIOpenWeather.RequestObject;
using practiceAPIOpenWeather.RequestObject.JsonPlaceHolderObj;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceAPIOpenWeather
{
    static class TestJsonPlaceHolderEndpoint
    {
        static string url =  "https://jsonplaceholder.typicode.com/posts";
        public const string sourceName = "bodyData";




        [TestCaseSource(typeof(Datasource_JsonPlaceHolderPost), sourceName)]
        [Test]
        public static void TestPostJsonPlaceHolder(IDictionary<string, string> info)
        {

            var client = new RestClient(url);

            var request = new RestRequest();

            InputObject body = InputObject.GetBodyObjectFromExcelFile(info);

            request.AddJsonBody(body);
            var response = client.Post(request);
            Console.WriteLine(response.StatusCode.ToString() + "     " + response.Content.ToString());
            


        }
    }
}
