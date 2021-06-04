using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceAPIOpenWeather.RequestObject.JsonPlaceHolderObj
{
    class InputObject
    {
        private string userID;
        private string body;
        private string title;

        public string UserID { get => userID; set => userID = value; }
        public string Body { get => body; set => body = value; }
        public string Title { get => title; set => title = value; }

        public static InputObject GetBodyObjectFromExcelFile(IDictionary<string, string> info)
        {
            var searchObject = new InputObject
            {
                userID = info["userID"],
                body = info["body"],
                title = info["title"]
              
            };
            return searchObject;


        }
    }
}
