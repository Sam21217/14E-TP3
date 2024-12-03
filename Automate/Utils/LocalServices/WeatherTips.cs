namespace Automate.Utils.LocalServices
{
    public static class WeatherTips
    {

        const int MAX_TEMP = 27;
        const int MIN_TEMP = 18;

        const int MAX_HUMIDITY = 80;
        const int MIN_HUMIDITY = 60;

        const int MAX_LUX = 45000;
        const int MIN_LUX = 25000;

        public static string GetTempTips(int temperature, bool heatingIsOn, bool windowsAreOpen)
        {
            if (temperature > MAX_TEMP)
            {
                if (heatingIsOn && windowsAreOpen)
                    return "DÉSACTIVER CHAUFFAGE CAR TEMPÉRATURE TROP HAUTE";

                if (!heatingIsOn && !windowsAreOpen)
                    return "OUVRIR FENÊTRES CAR TEMPÉRATURE TROP HAUTE";

                if (heatingIsOn && !windowsAreOpen)
                    return "DÉSACTIVER CHAUFFAGE ET OUVRIR FENÊTRES CAR TEMPÉRATURE TROP HAUTE";
            }
            if (temperature < MIN_TEMP)
            {
                if (!heatingIsOn && !windowsAreOpen)
                    return "ACTIVER CHAUFFAGE CAR TEMPÉRATURE TROP BASSE";

                if (heatingIsOn && windowsAreOpen)
                    return "FERMER FENÊTRES CAR TEMPÉRATURE TROP BASSE";

                if (!heatingIsOn && windowsAreOpen)
                    return "ACTIVER CHAUFFAGE ET FERMER FENÊTRES CAR TEMPÉRATURE TROP BASSE";
            }
            return "OK";
        }

        public static string GetHumidityTips(int humidity, bool ventilationIsOn, bool sprinklersAreOn)
        {
            if (humidity > MAX_HUMIDITY)
            {
                if (!ventilationIsOn && !sprinklersAreOn)
                    return "ACTIVER VENTILATION CAR HUMIDITÉ TROP HAUTE";

                if (ventilationIsOn && sprinklersAreOn)
                    return "DÉSACTIVER ARROSEURS CAR HUMIDITÉ TROP HAUTE";

                if (!ventilationIsOn && sprinklersAreOn)
                    return "ACTIVER VENTILATION ET DÉSACTIVER ARROSEURS CAR HUMIDITÉ TROP HAUTE";
            }
            if (humidity < MIN_HUMIDITY)
            {
                if (ventilationIsOn && sprinklersAreOn)
                    return "DÉSACTIVER VENTILATION CAR HUMIDITÉ TROP BASSE";

                if (!ventilationIsOn && !sprinklersAreOn)
                    return "ACTIVER ARROSEURS CAR HUMIDITÉ TROP BASSE";

                if (ventilationIsOn && !sprinklersAreOn)
                    return "DÉSACTIVER VENTILATION ET ACTIVER ARROSEURS CAR HUMIDITÉ TROP BASSE";
            }
            return "OK";
        }

        public static string GetLightingTips(int lighting, int time, bool lightsAreOn)
        {
            if (lighting > MAX_LUX && lightsAreOn)
                return "ÉTEINDRE LUMIÈRES CAR LUMINOSITÉ TROP FORTE";

            if (IsNight(time) && lightsAreOn)
                return "ÉTEINDRE LUMIÈRES CAR C'EST LA NUIT";

            if (lighting < MIN_LUX && !lightsAreOn && !IsNight(time))
                return "ALLUMER LUMIÈRES CAR LUMINOSITÉ TROP BASSE";

            return "OK"; 
        }

        static private bool IsNight(int time)
        {
            if (time > 20 || time < 6)
                return true;

            return false;
        }
    }
}
