using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Models
{
    public class OutsideConditions
    {
        public DateTime DateTime { get; set; }

        public int Temperature { get; set; }

        public int Humidity { get; set; }

        public int Lighting { get; set; }

        public OutsideConditions(DateTime dateTime, int temperature, int humidity, int lighting)
        {
            DateTime = dateTime;
            Temperature = temperature;
            Humidity = humidity;
            Lighting = lighting;
        }
    }
}
