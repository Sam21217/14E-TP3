using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Automate.Models;
namespace Automate.Utils.DataServices
{
    public class WeatherConditionsService
    {
        private const string DATA_FILE_PATH = "TempData.csv";

        public List<OutsideConditions> Conditions = new List<OutsideConditions>();

        public WeatherConditionsService()
        {
            AddDataToConditions(new StreamReader(DATA_FILE_PATH));
        }

        private void AddDataToConditions(StreamReader file)
        {
            string[] fileContent = file.ReadToEnd().Replace('\r', ' ').Split('\n');
            fileContent = fileContent.Skip(1).ToArray();
            foreach (string line in fileContent)
            {
                string[] lineContent = line.Split(',');
                Conditions.Add(CreateOutsideConditions(lineContent));
            }
        }

        private OutsideConditions CreateOutsideConditions(string[] lineContent)
        {
            DateTime dateTime = Convert.ToDateTime(lineContent[0]);
            int temp = int.Parse(lineContent[1]);
            int humidity = int.Parse(lineContent[2]);
            int lighting = int.Parse(lineContent[3]);
            return new OutsideConditions(dateTime, temp, humidity, lighting);
        }
    }
}
