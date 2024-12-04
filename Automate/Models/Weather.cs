using System;

namespace Automate.Models
{
    public class Weather
    {
        public DateTime DateTime { get; set; }

        public int Temperature { get; set; }

        public int Humidity { get; set; }

        public int Lighting { get; set; }

        public Weather(DateTime dateTime, int temperature, int humidity, int lighting)
        {
            DateTime = dateTime;
            Temperature = temperature;
            Humidity = humidity;
            Lighting = lighting;
        }
    }
}
