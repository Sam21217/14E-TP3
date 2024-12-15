using Automate.Utils.LocalServices;

namespace AutomateTests
{
    public class WeatherTipsTests
    {
        private const int TEMP_OVER_MAX = 30;
        private const int TEMP_UNDER_MIN = 15;
        private const int TEMP_OK = 23;

        private const int HUMIDITY_OVER_MAX = 90;
        private const int HUMIDITY_UNDER_MIN = 50;
        private const int HUMIDITY_OK = 70;

        private const int LUX_OVER_MAX = 50000;
        private const int LUX_UNDER_MIN = 20000;
        private const int LUX_OK = 35000;

        [Test]
        public void GetTempTips_TempOver_HeatingIsOn_WindowsAreOpen()
        {
            const string EXPECTED_MESSAGE = "DÉSACTIVER CHAUFFAGE CAR TEMPÉRATURE TROP HAUTE";

            string message = WeatherTips.GetTempTips(TEMP_OVER_MAX, true, true);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetTempTips_TempOver_HeatingIsNotOn_WindowsAreNotOpen()
        {
            const string EXPECTED_MESSAGE = "OUVRIR FENÊTRES CAR TEMPÉRATURE TROP HAUTE";

            string message = WeatherTips.GetTempTips(TEMP_OVER_MAX, false, false);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetTempTips_TempOver_HeatingIsOn_WindowsAreNotOpen()
        {
            const string EXPECTED_MESSAGE = "DÉSACTIVER CHAUFFAGE ET OUVRIR FENÊTRES CAR TEMPÉRATURE TROP HAUTE";

            string message = WeatherTips.GetTempTips(TEMP_OVER_MAX, true, false);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetTempTips_TempUnder_HeatingIsNotOn_WindowsAreNotOpen()
        {
            const string EXPECTED_MESSAGE = "ACTIVER CHAUFFAGE CAR TEMPÉRATURE TROP BASSE";

            string message = WeatherTips.GetTempTips(TEMP_UNDER_MIN, false, false);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetTempTips_TempUnder_HeatingIsOn_WindowsAreOpen()
        {
            const string EXPECTED_MESSAGE = "FERMER FENÊTRES CAR TEMPÉRATURE TROP BASSE";

            string message = WeatherTips.GetTempTips(TEMP_UNDER_MIN, true, true);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetTempTips_TempUnder_HeatingIsNotOn_WindowsAreOpen()
        {
            const string EXPECTED_MESSAGE = "ACTIVER CHAUFFAGE ET FERMER FENÊTRES CAR TEMPÉRATURE TROP BASSE";

            string message = WeatherTips.GetTempTips(TEMP_UNDER_MIN, false, true);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetTempTips_TempOK_HeatingIsNotOn_WindowsAreOpen()
        {
            const string EXPECTED_MESSAGE = "CHAUFFAGE EN ORDRE";

            string message = WeatherTips.GetTempTips(TEMP_OK, false, true);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetHumidityTips_HumidityOver_VentilationIsNotOn_SprinklersAreNotOn()
        {
            const string EXPECTED_MESSAGE = "ACTIVER VENTILATION CAR HUMIDITÉ TROP HAUTE";

            string message = WeatherTips.GetHumidityTips(HUMIDITY_OVER_MAX, false, false);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetHumidityTips_HumidityOver_VentilationIsOn_SprinklersAreOn()
        {
            const string EXPECTED_MESSAGE = "DÉSACTIVER ARROSEURS CAR HUMIDITÉ TROP HAUTE";

            string message = WeatherTips.GetHumidityTips(HUMIDITY_OVER_MAX, true, true);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetHumidityTips_HumidityOver_VentilationIsNotOn_SprinklersAreOn()
        {
            const string EXPECTED_MESSAGE = "ACTIVER VENTILATION ET DÉSACTIVER ARROSEURS CAR HUMIDITÉ TROP HAUTE";

            string message = WeatherTips.GetHumidityTips(HUMIDITY_OVER_MAX, false, true);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetHumidityTips_HumidityUnder_VentilationIsOn_SprinklersAreOn()
        {
            const string EXPECTED_MESSAGE = "DÉSACTIVER VENTILATION CAR HUMIDITÉ TROP BASSE";

            string message = WeatherTips.GetHumidityTips(HUMIDITY_UNDER_MIN, true, true);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetHumidityTips_HumidityUnder_VentilationIsNotOn_SprinklersAreNotOn()
        {
            const string EXPECTED_MESSAGE = "ACTIVER ARROSEURS CAR HUMIDITÉ TROP BASSE";

            string message = WeatherTips.GetHumidityTips(HUMIDITY_UNDER_MIN, false, false);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetHumidityTips_HumidityUnder_VentilationIsOn_SprinklersAreNotOn()
        {
            const string EXPECTED_MESSAGE = "DÉSACTIVER VENTILATION ET ACTIVER ARROSEURS CAR HUMIDITÉ TROP BASSE";

            string message = WeatherTips.GetHumidityTips(HUMIDITY_UNDER_MIN, true, false);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetHumidityTips_HumidityOK_VentilationIsOn_SprinklersAreNotOn()
        {
            const string EXPECTED_MESSAGE = "HUMIDITÉ EN ORDRE";

            string message = WeatherTips.GetHumidityTips(HUMIDITY_OK, true, false);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetLightingTips_LightingOver_LightsAreOn()
        {
            const string EXPECTED_MESSAGE = "ÉTEINDRE LUMIÈRES CAR LUMINOSITÉ TROP FORTE";
            const int time = 10;

            string message = WeatherTips.GetLightingTips(LUX_OVER_MAX, time, true);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetLightingTips_LightingUnder_AtNoon_LightsAreOff()
        {
            const string EXPECTED_MESSAGE = "ALLUMER LUMIÈRES CAR LUMINOSITÉ TROP BASSE";
            const int time = 11;

            string message = WeatherTips.GetLightingTips(LUX_UNDER_MIN, time, false);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetLightingTips_LightingOK_LightsAreOn_AtMidnight()
        {
            const string EXPECTED_MESSAGE = "ÉTEINDRE LUMIÈRES CAR C'EST LA NUIT";
            const int time = 23;

            string message = WeatherTips.GetLightingTips(LUX_OK, time, true);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetLightingTips_LightingUnder_AtMidnight_LightsAreOff()
        {
            const string EXPECTED_MESSAGE = "ÉCLAIRAGE EN ORDRE";
            const int time = 23;

            string message = WeatherTips.GetLightingTips(LUX_UNDER_MIN, time, false);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }

        [Test]
        public void GetLightingTips_LightingOK_AtNoon()
        {
            const string EXPECTED_MESSAGE = "ÉCLAIRAGE EN ORDRE";
            const int time = 11;

            string message = WeatherTips.GetLightingTips(LUX_OK, time, false);

            Assert.That(message, Is.EqualTo(EXPECTED_MESSAGE));
        }
    }
}
