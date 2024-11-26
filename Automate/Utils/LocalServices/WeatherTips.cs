using Automate.Models;
using MongoDB.Driver.Core.WireProtocol.Messages.Encoders.BinaryEncoders;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Utils.LocalServices
{
    public class WeatherTips
    {

        const int MAX_TEMP = 27;
        const int MIN_TEMP = 18;

        const int MAX_HUMIDITY = 80;
        const int MIN_HUMIDITY = 60;

        const int MAX_LUX = 45000;
        const int MIN_LUX = 25000;

        public string GetTempTips(int temperature, bool heatingIsOn, bool windowsAreOpen)
        {
            if (temperature > MAX_TEMP)
            {
                if (heatingIsOn && windowsAreOpen)
                    return "DÉSACTIVER CHAUFFAGE";

                if (!heatingIsOn && !windowsAreOpen)
                    return "OUVRIR FENÊTRES";

                if (heatingIsOn && !windowsAreOpen)
                    return "DÉSACTIVER CHAUFFAGE et OUVRIR FENÊTRES";
            }
            if (temperature < MIN_TEMP)
            {
                if (!heatingIsOn && !windowsAreOpen)
                    return "ACTIVER CHAUFFAGE";

                if (heatingIsOn && windowsAreOpen)
                    return "FERMER FENÊTRES";

                if (!heatingIsOn && windowsAreOpen)
                    return "ACTIVER CHAUFFAGE et FERMER FENÊTRES";
            }
            return "OK";
        }

        public string GetHumidityTips(int humidity, bool ventilationIsOn, bool sprinklersAreOn)
        {
            if (humidity > MAX_HUMIDITY)
            {
                if (!ventilationIsOn && !sprinklersAreOn)
                    return "ACTIVER VENTILATION";

                if (ventilationIsOn && sprinklersAreOn)
                    return "DÉSACTIVER ARROSEURS";

                if (!ventilationIsOn && sprinklersAreOn)
                    return "ACTIVER VENTILATION et DÉSACTIVER ARROSEURS";
            }
            if (humidity < MIN_HUMIDITY)
            {
                if (ventilationIsOn && sprinklersAreOn)
                    return "DÉSACTIVER VENTILATION";

                if (!ventilationIsOn && !sprinklersAreOn)
                    return "ACTIVER ARROSEURS";

                if (ventilationIsOn && !sprinklersAreOn)
                    return "DÉSACTIVER VENTILATION et ACTIVER ARROSEURS";
            }
            return "OK";
        }

        public string CheckLighting(int lighting, bool lightsAreOn)
        {
            if (lighting > MAX_LUX && lightsAreOn)
                return "ÉTEINDRE LUMIÈRES";
            if (lighting < MIN_LUX && !lightsAreOn)
                return "ALLUMER LUMIÈRES";

            return "OK"; 
        }
    }
}
