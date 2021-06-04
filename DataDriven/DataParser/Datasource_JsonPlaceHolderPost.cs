using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceAPIOpenWeather.RequestObject
{
    public class Datasource_JsonPlaceHolderPost
    {
        
        public static IEnumerable bodyData => Utilities.ExcelDataReader.ReadXlsxDataDriveFile(GetDataFile(), "Sheet1");

        private static string GetDataFile()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["DataPath"];
            return new Uri(path).LocalPath;
        }
    }
}
