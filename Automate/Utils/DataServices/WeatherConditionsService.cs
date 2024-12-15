using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Automate.Models;

namespace Automate.Utils.DataServices
{
    public static class WeatherConditionsService
    {
        private const string DATA_FILE_PATH = "TempData.csv";

        public static List<Weather> GetWeathers()
        {
            List<Weather> Conditions = new List<Weather>();
            StreamReader file = new StreamReader(DATA_FILE_PATH);
            string[] fileContent = file.ReadToEnd().Replace('\r', ' ').Split('\n');
            fileContent = fileContent.Skip(1).ToArray();
            foreach (string line in fileContent)
            {
                string[] lineContent = line.Split(',');
                Conditions.Add(CreateOutsideConditions(lineContent));
            }
            return Conditions;
        }

        private static Weather CreateOutsideConditions(string[] lineContent)
        {
            DateTime dateTime = Convert.ToDateTime(lineContent[0]);
            int temp = int.Parse(lineContent[1]);
            int humidity = int.Parse(lineContent[2]);
            int lighting = int.Parse(lineContent[3]);
            return new Weather(dateTime, temp, humidity, lighting);
        }
    }
}
